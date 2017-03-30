// Script to pack and push all nuget packages
//to run:
//node scripts/publish.js 1.0.0
var fs = require('fs');
var path = require('path');
var child = require('child_process');
const OUTPUT = 'output'

var version = process.argv[2];
if (!version)
    throw new Error('specify version to package as first argument')


var nugetApiKey = process.env.NUGET_APIKEY;
if (!version)
    throw new Error('make sure you have NUGET_APIKEY set as env variable to push the package')

var releaseNotes = fs.readFileSync('release-notes.md').toString();

if (!fs.existsSync(OUTPUT)) {
    fs.mkdirSync(OUTPUT);
}

var paths = fs.readdirSync('src');

var toPublish = paths.filter(x => x.indexOf('Test') === -1); //dont publish projects containing the word Test in the name

toPublish.forEach(project => {
    console.log(`packing ${project}`);
    var projFile = path.join('src', project, project +'.csproj');
    var original = fs.readFileSync(projFile).toString();
    //var json = JSON.parse(original);

    
    var newCsproj = original.replace(/<VersionPrefix>([\d.]+)<\/VersionPrefix>/,match => `<VersionPrefix>${version}</VersionPrefix>`)
    //json.version = version;
    //todo release notes
    //json.packOptions.releaseNotes = releaseNotes;

    fs.writeFileSync(projFile, newCsproj);
    child.execFileSync("dotnet", ["pack", '-c', 'Release', '-o', path.resolve(OUTPUT), path.join('src', project)]);
    fs.writeFileSync(projFile, original);

    console.log(`pushing ${project}`);
    //not publishing symbols
    var package = path.join(OUTPUT, `${project}.${version}.nupkg`);
    child.execFileSync("nuget", ["push", package, '-Source', 'https://www.nuget.org/api/v2/package', '-ApiKey', nugetApiKey]);
});
