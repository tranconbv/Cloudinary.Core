using System;
using System.Collections.Generic;
using CloudinaryDotNet.Actions;

namespace CloudinaryDotNet
{
    public static class CloudinarySyncExtensions
    {
        public static UploadMappingResults DeleteUploadMapping(this Cloudinary cloudinary)
        {
            return cloudinary.DeleteUploadMapping(string.Empty);
        }

        public static DelResResult DeleteResources(this Cloudinary cloudinary, ResourceType type, params string[] publicIds)
        {
            var parameters = new DelResParams {ResourceType = type};
            parameters.PublicIds.AddRange(publicIds);
            return cloudinary.DeleteResources(parameters);
        }

        public static DelResResult DeleteResources(this Cloudinary cloudinary, params string[] publicIds)
        {
            var parameters = new DelResParams();
            parameters.PublicIds.AddRange(publicIds);
            return cloudinary.DeleteResources(parameters);
        }

        public static DelResResult DeleteAllResources(this Cloudinary cloudinary)
        {
            return cloudinary.DeleteResources(new DelResParams {All = true});
        }

        public static DelResResult DeleteAllResources(this Cloudinary cloudinary, bool keepOriginal, string nextCursor)
        {
            return cloudinary.DeleteResources(new DelResParams {All = true, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public static DelDerivedResResult DeleteDerivedResources(this Cloudinary cloudinary, params string[] ids)
        {
            var parameters = new DelDerivedResParams();
            parameters.DerivedResources.AddRange(ids);
            return cloudinary.DeleteDerivedResources(parameters);
        }

        public static  DelResResult DeleteResourcesByPrefix(this Cloudinary cloudinary, string prefix)
        {
            return cloudinary.DeleteResources(new DelResParams {Prefix = prefix});
        }

        public static  DelResResult DeleteResourcesByPrefix(this Cloudinary cloudinary, string prefix, bool keepOriginal, string nextCursor)
        {
            return cloudinary.DeleteResources(new DelResParams {Prefix = prefix, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public static  DelResResult DeleteResourcesByTag(this Cloudinary cloudinary, string tag)
        {
            return cloudinary.DeleteResources(new DelResParams {Tag = tag});
        }

        public static  DelResResult DeleteResourcesByTag(this Cloudinary cloudinary, string tag, bool keepOriginal, string nextCursor)
        {
            return cloudinary.DeleteResources(new DelResParams {Tag = tag, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public static ListResourcesResult ListResources(this Cloudinary cloudinary, string nextCursor = null, bool tags = true, bool context = true, bool moderations = true)
        {
            return cloudinary.ListResources(new ListResourcesParams {NextCursor = nextCursor, Tags = tags, Context = context, Moderations = moderations});
        }


        public static ListResourcesResult ListResourceByPublicIds(this Cloudinary cloudinary, IEnumerable<string> publicIds, bool tags, bool context, bool moderations)
        {
            var specificResourcesParams = new ListSpecificResourcesParams
            {
                PublicIds = new List<string>(publicIds),
                Tags = tags,
                Context = context,
                Moderations = moderations
            };
            return cloudinary.ListResources(specificResourcesParams);
        }

        public static ListResourcesResult ListResourcesByModerationStatus(this Cloudinary cloudinary, string kind, ModerationStatus status, bool tags = true, bool context = true, bool moderations = true, string nextCursor = null)
        {
            var moderationParams = new ListResourcesByModerationParams
            {
                ModerationKind = kind,
                ModerationStatus = status,
                Tags = tags,
                Context = context,
                Moderations = moderations,
                NextCursor = nextCursor
            };
            return cloudinary.ListResources(moderationParams);
        }

        public static ListResourcesResult ListResourcesByPrefix(this Cloudinary cloudinary, string prefix, string type = "upload", string nextCursor = null)
        {
            var resourcesByPrefixParams = new ListResourcesByPrefixParams
            {
                Type = type,
                Prefix = prefix,
                NextCursor = nextCursor
            };
            return cloudinary.ListResources(resourcesByPrefixParams);
        }

        public static ListResourcesResult ListResourcesByPrefix(this Cloudinary cloudinary, string prefix, bool tags, bool context, bool moderations, string type = "upload", string nextCursor = null)
        {
            var resourcesByPrefixParams = new ListResourcesByPrefixParams
            {
                Tags = tags,
                Context = context,
                Moderations = moderations,
                Type = type,
                Prefix = prefix,
                NextCursor = nextCursor
            };
            return cloudinary.ListResources(resourcesByPrefixParams);
        }

        public static ListResourcesResult ListResourcesByPublicIds(this Cloudinary cloudinary, IEnumerable<string> publicIds)
        {
            return cloudinary.ListResources(new ListSpecificResourcesParams {PublicIds = new List<string>(publicIds)});
        }

        public static ListResourcesResult ListResourcesByTag(this Cloudinary cloudinary, string tag, string nextCursor = null)
        {
            var resourcesByTagParams = new ListResourcesByTagParams
            {
                Tag = tag,
                NextCursor = nextCursor
            };
            return cloudinary.ListResources(resourcesByTagParams);
        }

        public static ListResourcesResult ListResourcesByType(this Cloudinary cloudinary, string type, string nextCursor = null)
        {
            return cloudinary.ListResources(new ListResourcesParams {Type = type, NextCursor = nextCursor});
        }


        public static ListTagsResult ListTagsByPrefix(this Cloudinary cloudinary, string prefix)
        {
            return cloudinary.ListTags(new ListTagsParams {Prefix = prefix});
        }


        public static ListTransformsResult ListTransformations(this Cloudinary cloudinary)
        {
            return cloudinary.ListTransformations(new ListTransformsParams());
        }

        public static ListUploadPresetsResult ListUploadPresets(this Cloudinary cloudinary, string nextCursor = null)
        {
            return cloudinary.ListUploadPresets(new ListUploadPresetsParams {NextCursor = nextCursor});
        }

        public static RenameResult Rename(this Cloudinary cloudinary, string fromPublicId, string toPublicId, bool overwrite = false)
        {
            return cloudinary.Rename(new RenameParams(fromPublicId, toPublicId) {Overwrite = overwrite});
        }

        public static RestoreResult Restore(this Cloudinary cloudinary, params string[] publicIds)
        {
            var parameters = new RestoreParams();
            parameters.PublicIds.AddRange(publicIds);
            return cloudinary.Restore(parameters);
        }

        public static TextResult Text(this Cloudinary cloudinary, string text)
        {
            return cloudinary.Text(new TextParams(text));
        }

        public static GetResourceResult UpdateResource(this Cloudinary cloudinary, string publicId, ModerationStatus moderationStatus)
        {
            return cloudinary.UpdateResource(new UpdateParams(publicId) {ModerationStatus = moderationStatus});
        }

        public static UploadMappingResults UploadMapping(this Cloudinary cloudinary, string folder)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder must be specified.");
            return cloudinary. UploadMappings(new UploadMappingParams {Folder = folder});
        }

        public static GetResourceResult GetResource(this Cloudinary cloudinary, string publicId)
        {
            return cloudinary.GetResource(new GetResourceParams(publicId));
        }

        public static GetTransformResult GetTransform(this Cloudinary cloudinary, string transform)
        {
            return cloudinary.GetTransform(new GetTransformParams {Transformation = transform});
        }

        public static ListTagsResult ListTags(this Cloudinary cloudinary)
        {
            return cloudinary.ListTags(new ListTagsParams());
        }


        public static RawUploadResult UploadLarge(this Cloudinary cloudinary, RawUploadParams parameters, int bufferSize = 20971520)
        {
            return cloudinary.UploadLarge<RawUploadResult>(parameters, bufferSize);
        }

        public static ImageUploadResult UploadLarge(this Cloudinary cloudinary, ImageUploadParams parameters, int bufferSize = 20971520)
        {
            return cloudinary.UploadLarge<ImageUploadResult>(parameters, bufferSize);
        }

        public static VideoUploadResult UploadLarge(this Cloudinary cloudinary, VideoUploadParams parameters, int bufferSize = 20971520)
        {
            return cloudinary.UploadLarge<VideoUploadResult>(parameters, bufferSize);
        }

        [Obsolete("Use UploadLarge(parameters, bufferSize) instead.")]
        public static UploadResult UploadLarge(this Cloudinary cloudinary, BasicRawUploadParams parameters, int bufferSize = 20971520, bool isRaw = false)
        {
            if (isRaw)
                return cloudinary.UploadLarge<RawUploadResult>(parameters, bufferSize);
            return cloudinary.UploadLarge<ImageUploadResult>(parameters, bufferSize);
        }

        [Obsolete("Use UploadLarge(parameters, bufferSize) instead.")]
        public static RawUploadResult UploadLargeRaw(this Cloudinary cloudinary, BasicRawUploadParams parameters, int bufferSize = 20971520)
        {
            if (parameters is RawUploadParams)
                throw new ArgumentException("Please use BasicRawUploadParams class for large raw file uploading!");
            parameters.Check();
            if (parameters.File.IsRemote)
                throw new ArgumentException("The UploadLargeRaw method is intended to be used for large local file uploading and can't be used for remote file uploading!");
            return cloudinary.UploadLarge(parameters, bufferSize, true) as RawUploadResult;
        }
    }
}