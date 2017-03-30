# Cloudinary core

This is a direct port from CloudinaryDotNet official nuget package. so namespaces are (yet) the same, and all code should be the same.

Although code is split up over several nuget packages to reduce footprint if you just want to use the basic api calls.

* [Cloudinary.Core](https://www.nuget.org/packages/Cloudinary.Core/) => main package
* [Cloudinary.Core.Sync](https://www.nuget.org/packages/Cloudinary.Core.Sync/) => Package containing original (not async) api calls.
* [Cloudinary.Core.DependencyInjection](https://www.nuget.org/packages/Cloudinary.Core.DependencyInjection/) => containing simple helper methods to add Cloudinary as dependency.
* [Cloudinary.Core.Html](https://www.nuget.org/packages/Cloudinary.Core.Html/) => containing original code for generating html.

## Usages


```cs
var client = new Cloudinary("cloudinary://urlFromYourDashboard");
var sample = Cloudinary.GetResource("sample");
```


depdency DependencyInjection

```cs
IServiceCollection services.AddCloudinary(); //will get CLOUDINARY_URL env variable for authentication
//or services.AddCloudinary(new Account(user, key));
var sample = Cloudinary.GetResource("sample");

//It will get injected in constructor now.
constructor(Cloudinary cloudinary){
    cloudinary.DoApiCall();
}

```


#Contributing

Contributions are welcome, for and make a pull request as you wish.

This repo uses node npm package.json scripts for easy build and packing
without ide, but you'll need to have installed node on your system.

```bash
npm run build #builds all non test projects
npm test #tests all projects
npm run pack #creates nuget packages in git root.
```