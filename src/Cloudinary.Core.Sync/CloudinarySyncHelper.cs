using System.Collections.Generic;
using System.Net.Http;
using CloudinaryDotNet.Actions;

namespace CloudinaryDotNet
{
    public static class CloudinarySyncHelper
    {

        public static ArchiveResult CreateArchive(this Cloudinary cloudinary, ArchiveParams parameters)
        {
            return cloudinary.CreateArchiveAsync(parameters).ExecSync();
        }

        public static TransformResult CreateTransform(this Cloudinary cloudinary, CreateTransformParams parameters)
        {
            return cloudinary.CreateTransformAsync(parameters).ExecSync();
        }

        public static UploadMappingResults CreateUploadMapping(this Cloudinary cloudinary, string folder, string template)
        {
            return cloudinary.CreateUploadMappingAsync(folder,template).ExecSync();
        }

        public static UploadPresetResult CreateUploadPreset(this Cloudinary cloudinary, UploadPresetParams parameters)
        {
            return cloudinary.CreateUploadPresetAsync(parameters).ExecSync();
        }

        public static DelDerivedResResult DeleteDerivedResources(this Cloudinary cloudinary, DelDerivedResParams parameters)
        {
            return cloudinary.DeleteDerivedResourcesAsync(parameters).ExecSync();
        }

        public static DelResResult DeleteResources(this Cloudinary cloudinary, DelResParams parameters)
        {
            return cloudinary.DeleteResourcesAsync(parameters).ExecSync();
        }

        public static TransformResult DeleteTransform(this Cloudinary cloudinary, string transformName)
        {
            return cloudinary.DeleteTransformAsync(transformName).ExecSync();
        }

        public static UploadMappingResults DeleteUploadMapping(this Cloudinary cloudinary, string folder)
        {
            return cloudinary.DeleteUploadMappingAsync(folder).ExecSync();
        }

        public static DeleteUploadPresetResult DeleteUploadPreset(this Cloudinary cloudinary, string name)
        {
            return cloudinary.DeleteUploadPresetAsync(name).ExecSync();
        }

        public static DeletionResult Destroy(this Cloudinary cloudinary, DeletionParams parameters)
        {
            return cloudinary.DestroyAsync(parameters).ExecSync();
        }

        public static ExplicitResult Explicit(this Cloudinary cloudinary, ExplicitParams parameters)
        {
            return cloudinary.ExplicitAsync(parameters).ExecSync();
        }

        public static ExplodeResult Explode(this Cloudinary cloudinary, ExplodeParams parameters)
        {
            return cloudinary.ExplodeAsync(parameters).ExecSync();
        }

        public static GetResourceResult GetResource(this Cloudinary cloudinary, GetResourceParams parameters)
        {
            return cloudinary.GetResourceAsync(parameters).ExecSync();
        }

        public static GetTransformResult GetTransform(this Cloudinary cloudinary, GetTransformParams parameters)
        {
            return cloudinary.GetTransformAsync(parameters).ExecSync();
        }

        public static GetUploadPresetResult GetUploadPreset(this Cloudinary cloudinary, string name)
        {
            return cloudinary.GetUploadPresetAsync(name).ExecSync();
        }

        public static UsageResult GetUsage(this Cloudinary cloudinary)
        {
            return cloudinary.GetUsageAsync().ExecSync();
        }

        public static ListResourcesResult ListResources(this Cloudinary cloudinary, ListResourcesParams parameters)
        {
            return cloudinary.ListResourcesAsync(parameters).ExecSync();
        }

        public static ListResourceTypesResult ListResourceTypes(this Cloudinary cloudinary)
        {
            return cloudinary.ListResourceTypesAsync().ExecSync();
        }

        public static ListTagsResult ListTags(this Cloudinary cloudinary, ListTagsParams parameters)
        {
            return cloudinary.ListTagsAsync(parameters).ExecSync();
        }

        public static ListTransformsResult ListTransformations(this Cloudinary cloudinary, ListTransformsParams parameters)
        {
            return cloudinary.ListTransformationsAsync(parameters).ExecSync();
        }

        public static ListUploadPresetsResult ListUploadPresets(this Cloudinary cloudinary, ListUploadPresetsParams parameters)
        {
            return cloudinary.ListUploadPresetsAsync(parameters).ExecSync();
        }

        public static SpriteResult MakeSprite(this Cloudinary cloudinary, SpriteParams parameters)
        {
            return cloudinary.MakeSpriteAsync(parameters).ExecSync();
        }

        public static MultiResult Multi(this Cloudinary cloudinary, MultiParams parameters)
        {
            return cloudinary.MultiAsync(parameters).ExecSync();
        }

        public static RenameResult Rename(this Cloudinary cloudinary, RenameParams parameters)
        {
            return cloudinary.RenameAsync(parameters).ExecSync();
        }

        public static RestoreResult Restore(this Cloudinary cloudinary, RestoreParams parameters)
        {
            return cloudinary.RestoreAsync(parameters).ExecSync();
        }

        public static GetFoldersResult RootFolders(this Cloudinary cloudinary)
        {
            return cloudinary.RootFoldersAsync().ExecSync();
        }

        public static GetFoldersResult SubFolders(this Cloudinary cloudinary, string folder)
        {
            return cloudinary.SubFoldersAsync(folder).ExecSync();
        }

        public static TagResult Tag(this Cloudinary cloudinary, TagParams parameters)
        {
            return cloudinary.TagAsync(parameters).ExecSync();
        }

        public static TextResult Text(this Cloudinary cloudinary, TextParams parameters)
        {
            return cloudinary.TextAsync(parameters).ExecSync();
        }

        public static GetResourceResult UpdateResource(this Cloudinary cloudinary, UpdateParams parameters)
        {
            return cloudinary.UpdateResourceAsync(parameters).ExecSync();
        }

        public static UpdateTransformResult UpdateTransform(this Cloudinary cloudinary, UpdateTransformParams parameters)
        {
            return cloudinary.UpdateTransformAsync(parameters).ExecSync();
        }

        public static UploadMappingResults UpdateUploadMapping(this Cloudinary cloudinary, string folder, string newTemplate)
        {
            return cloudinary.UpdateUploadMappingAsync(folder, newTemplate).ExecSync();
        }

        public static UploadPresetResult UpdateUploadPreset(this Cloudinary cloudinary, UploadPresetParams parameters)
        {
            return cloudinary.UpdateUploadPresetAsync(parameters).ExecSync();
        }

        public static ImageUploadResult Upload(this Cloudinary cloudinary, ImageUploadParams parameters)
        {
            return cloudinary.UploadAsync(parameters).ExecSync();
        }

        public static VideoUploadResult Upload(this Cloudinary cloudinary, VideoUploadParams parameters)
        {
            return cloudinary.UploadAsync(parameters).ExecSync();
        }

        public static RawUploadResult Upload(this Cloudinary cloudinary, string resourceType, IDictionary<string, object> parameters, FileDescription fileDescription)
        {
            return cloudinary.UploadAsync(resourceType, parameters, fileDescription).ExecSync();
        }

        public static RawUploadResult Upload(this Cloudinary cloudinary, RawUploadParams parameters, string type = "auto")
        {
            return cloudinary.UploadAsync(parameters, type).ExecSync();
        }

        public static T UploadLarge<T>(this Cloudinary cloudinary, BasicRawUploadParams parameters, int bufferSize = 20971520) where T : UploadResult, new()
        {
            return cloudinary.UploadLargeAsync<T>(parameters, bufferSize).ExecSync();
        }

        public static UploadMappingResults UploadMappings(this Cloudinary cloudinary, UploadMappingParams parameters)
        {
            return cloudinary.UploadMappingsAsync(parameters).ExecSync();
        }
    }
}