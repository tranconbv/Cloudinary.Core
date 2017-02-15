using System;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Xunit;

namespace Cloudinary.Tests
{
    public class Tests
    {
        public CloudinaryDotNet.Cloudinary Cloudinary { get; set; }
        public Tests()
        {
            if(string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CLOUDINARY_URL")))
                throw new Exception("CLOUDINARY_URL should be set");

            Cloudinary = new CloudinaryDotNet.Cloudinary();
        }

        private Stream ReadFile(string path){
            var dir = Directory.GetCurrentDirectory();
            if (dir.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}Debug"))
                dir = dir.Substring(0, dir.IndexOf($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}Debug", StringComparison.Ordinal));
            if(!dir.EndsWith("Cloudinary.Tests"))
                dir = Path.Combine(dir,"src","Cloudinary.Tests");
            return File.Open(Path.Combine(dir, path), FileMode.Open);
        }

        [Fact]
        public void TestSample()
        {
            var getResult = Cloudinary.GetResource("sample");

            Assert.NotNull(getResult);
            Assert.Equal(getResult.PublicId, "sample");
        }

        [Fact]
        public async void TestUpload(){
            var file = Path.Combine("data", "logo.png");
            var r = await Cloudinary.UploadAsync(new ImageUploadParams(){
                PublicId = "testing1",
                File = new FileDescription("logo.png",this.ReadFile(file)),
                Folder= "test"
            });
            Assert.Equal("test/testing1",r.PublicId);
            Assert.Null(r.Error);

            var getResult = await Cloudinary.GetResourceAsync(new GetResourceParams("test/testing1"));
            Assert.Null(getResult.Error);
            Assert.Equal(getResult.PublicId,"test/testing1");

            var delPar = new DelResParams();
            delPar.PublicIds.Add("test/testing1");
            var delResult = await Cloudinary.DeleteResourcesAsync(delPar);
            Assert.Null(delResult.Error);

            getResult = await Cloudinary.GetResourceAsync(new GetResourceParams("test/testing1"));
            Assert.NotNull(getResult.Error);

        }
    }
}
