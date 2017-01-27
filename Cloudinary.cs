// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Cloudinary
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;

namespace CloudinaryDotNet
{
    public class Cloudinary
    {
        public const string CF_SHARED_CDN = "d3jpl91pxevbkh.cloudfront.net";
        public const string OLD_AKAMAI_SHARED_CDN = "cloudinary-a.akamaihd.net";
        public const string AKAMAI_SHARED_CDN = "res.cloudinary.com";
        public const string SHARED_CDN = "res.cloudinary.com";
        private const string RESOURCE_TYPE_IMAGE = "image";
        private const string ACTION_GENERATE_ARCHIVE = "generate_archive";
        private static readonly Random m_random = new Random();

        public Cloudinary()
        {
            Api = new Api();
        }

        public Cloudinary(string cloudinaryUrl)
        {
            Api = new Api(cloudinaryUrl);
        }

        public Cloudinary(Account account)
        {
            Api = new Api(account);
        }

        public Api Api { get; }

        public Task<RawUploadResult> UploadLargeRawAsync(BasicRawUploadParams parameters, int bufferSize = 20971520)
        {
            return Task.Factory.StartNew(o =>
            {
                var tuple = (Tuple<BasicRawUploadParams, int>) o;
                return UploadLargeRaw(tuple.Item1, tuple.Item2);
            }, new Tuple<BasicRawUploadParams, int>(parameters, bufferSize));
        }

        public Task<RawUploadResult> UploadAsync(RawUploadParams parameters, string type = "auto")
        {
            return Task.Factory.StartNew(o =>
            {
                var tuple = (Tuple<RawUploadParams, string>) o;
                return Upload(tuple.Item1, tuple.Item2);
            }, new Tuple<RawUploadParams, string>(parameters, type));
        }

        public Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters)
        {
            return CallAsync(Upload, parameters);
        }

        public Task<ExplicitResult> ExplicitAsync(ExplicitParams parameters)
        {
            return CallAsync(Explicit, parameters);
        }

        public Task<RenameResult> RenameAsync(RenameParams parameters)
        {
            return CallAsync(Rename, parameters);
        }

        public Task<DeletionResult> DestroyAsync(DeletionParams parameters)
        {
            return CallAsync(Destroy, parameters);
        }

        public Task<TextResult> TextAsync(TextParams parameters)
        {
            return CallAsync(Text, parameters);
        }

        public Task<TagResult> TagAsync(TagParams parameters)
        {
            return CallAsync(Tag, parameters);
        }

        public Task<ListResourcesResult> ListResourcesAsync(ListResourcesParams parameters)
        {
            return CallAsync(ListResources, parameters);
        }

        public Task<ListTagsResult> ListTagsAsync(ListTagsParams parameters)
        {
            return CallAsync(ListTags, parameters);
        }

        public Task<ListTransformsResult> ListTransformationsAsync(ListTransformsParams parameters)
        {
            return CallAsync(ListTransformations, parameters);
        }

        public Task<GetTransformResult> GetTransformAsync(GetTransformParams parameters)
        {
            return CallAsync(GetTransform, parameters);
        }

        public Task<GetResourceResult> UpdateResourceAsync(UpdateParams parameters)
        {
            return CallAsync(UpdateResource, parameters);
        }

        public Task<GetResourceResult> GetResourceAsync(GetResourceParams parameters)
        {
            return CallAsync(GetResource, parameters);
        }

        public Task<DelDerivedResResult> DeleteDerivedResourcesAsync(DelDerivedResParams parameters)
        {
            return CallAsync(DeleteDerivedResources, parameters);
        }

        public Task<DelResResult> DeleteResourcesAsync(DelResParams parameters)
        {
            return CallAsync(DeleteResources, parameters);
        }

        public Task<UpdateTransformResult> UpdateTransformAsync(UpdateTransformParams parameters)
        {
            return CallAsync(UpdateTransform, parameters);
        }

        public Task<TransformResult> CreateTransformAsync(CreateTransformParams parameters)
        {
            return CallAsync(CreateTransform, parameters);
        }

        public Task<SpriteResult> MakeSpriteAsync(SpriteParams parameters)
        {
            return CallAsync(MakeSprite, parameters);
        }

        public Task<MultiResult> MultiAsync(MultiParams parameters)
        {
            return CallAsync(Multi, parameters);
        }

        public Task<ExplodeResult> ExplodeAsync(ExplodeParams parameters)
        {
            return CallAsync(Explode, parameters);
        }

        public Task<UsageResult> GetUsageAsync()
        {
            return Task.Factory.StartNew(GetUsage);
        }

        private Task<TRes> CallAsync<TParams, TRes>(Func<TParams, TRes> f, TParams @params)
        {
            return Task.Factory.StartNew(o => f(@params), @params);
        }

        public ExplicitResult Explicit(ExplicitParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("explicit").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return ExplicitResult.Parse(response);
            }
        }

        public UploadPresetResult CreateUploadPreset(UploadPresetParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlV.Add("upload_presets").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return UploadPresetResult.Parse(response);
            }
        }

        public UploadPresetResult UpdateUploadPreset(UploadPresetParams parameters)
        {
            var paramsDictionary = parameters.ToParamsDictionary();
            paramsDictionary.Remove("name");
            using (var response = Api.Call(HttpMethod.PUT, Api.ApiUrlV.Add("upload_presets").Add(parameters.Name).BuildUrl(), paramsDictionary, null, null))
            {
                return UploadPresetResult.Parse(response);
            }
        }

        public GetUploadPresetResult GetUploadPreset(string name)
        {
            using (var response = Api.Call(HttpMethod.GET, Api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), null, null, null))
            {
                return GetUploadPresetResult.Parse(response);
            }
        }

        public ListUploadPresetsResult ListUploadPresets(string nextCursor = null)
        {
            return ListUploadPresets(new ListUploadPresetsParams {NextCursor = nextCursor});
        }

        public ListUploadPresetsResult ListUploadPresets(ListUploadPresetsParams parameters)
        {
            using (var response = Api.Call(HttpMethod.GET, new UrlBuilder(Api.ApiUrlV.Add("upload_presets").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return ListUploadPresetsResult.Parse(response);
            }
        }

        public DeleteUploadPresetResult DeleteUploadPreset(string name)
        {
            using (var response = Api.Call(HttpMethod.DELETE, Api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), null, null, null))
            {
                return DeleteUploadPresetResult.Parse(response);
            }
        }

        public ImageUploadResult Upload(ImageUploadParams parameters)
        {
            var url = Api.ApiUrlImgUpV.BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = Api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return ImageUploadResult.Parse(response);
            }
        }

        public VideoUploadResult Upload(VideoUploadParams parameters)
        {
            var url = Api.ApiUrlVideoUpV.BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = Api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return VideoUploadResult.Parse(response);
            }
        }

        public RawUploadResult Upload(string resourceType, IDictionary<string, object> parameters, FileDescription fileDescription)
        {
            var url = Api.ApiUrlV.Action("upload").ResourceType(resourceType).BuildUrl();
            ResetInternalFileDescription(fileDescription, int.MaxValue);
            if (parameters == null)
                parameters = new SortedDictionary<string, object>();
            if (!(parameters is SortedDictionary<string, object>))
                parameters = new SortedDictionary<string, object>(parameters);
            using (var response = Api.Call(HttpMethod.POST, url, (SortedDictionary<string, object>) parameters, fileDescription, null))
            {
                return RawUploadResult.Parse(response);
            }
        }

        public GetFoldersResult RootFolders()
        {
            using (var response = Api.Call(HttpMethod.GET, Api.ApiUrlV.Add("folders").BuildUrl(), null, null, null))
            {
                return GetFoldersResult.Parse(response);
            }
        }

        public GetFoldersResult SubFolders(string folder)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("folder must be set! Please use RootFolders() to get list of folders in root!");
            using (var response = Api.Call(HttpMethod.GET, Api.ApiUrlV.Add("folders").Add(folder).BuildUrl(), null, null, null))
            {
                return GetFoldersResult.Parse(response);
            }
        }

        public string DownloadPrivate(string publicId, bool? attachment = null, string format = "", string type = "")
        {
            if (string.IsNullOrEmpty(publicId))
                throw new ArgumentException("publicId");
            var builder = new UrlBuilder(Api.ApiUrlV.ResourceType("image").Action("download").BuildUrl());
            var sortedDictionary = new SortedDictionary<string, object>();
            sortedDictionary.Add("public_id", publicId);
            if (!string.IsNullOrEmpty(format))
                sortedDictionary.Add("format", format);
            if (attachment.HasValue)
                sortedDictionary.Add("attachment", attachment.Value ? "true" : "false");
            if (!string.IsNullOrEmpty(type))
                sortedDictionary.Add("type", type);
            return GetDownloadUrl(builder, sortedDictionary);
        }

        public string DownloadZip(string tag, Transformation transform)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentException("Tag should be specified!");
            var builder = new UrlBuilder(Api.ApiUrlV.ResourceType("image").Action("download_tag.zip").BuildUrl());
            var sortedDictionary = new SortedDictionary<string, object>();
            sortedDictionary.Add("tag", tag);
            if (transform != null)
                sortedDictionary.Add("transformation", transform.Generate());
            return GetDownloadUrl(builder, sortedDictionary);
        }

        public UsageResult GetUsage()
        {
            using (var response = Api.Call(HttpMethod.GET, Api.ApiUrlV.Action("usage").BuildUrl(), null, null, null))
            {
                return UsageResult.Parse(response);
            }
        }

        public RawUploadResult Upload(RawUploadParams parameters, string type = "auto")
        {
            var url = Api.ApiUrlImgUpV.ResourceType(type).BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = Api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return RawUploadResult.Parse(response);
            }
        }

        public RawUploadResult UploadLargeRaw(BasicRawUploadParams parameters, int bufferSize = 20971520)
        {
            if (parameters is RawUploadParams)
                throw new ArgumentException("Please use BasicRawUploadParams class for large raw file uploading!");
            parameters.Check();
            if (parameters.File.IsRemote)
                throw new ArgumentException("The UploadLargeRaw method is intended to be used for large local file uploading and can't be used for remote file uploading!");
            return UploadLarge(parameters, bufferSize, true) as RawUploadResult;
        }

        private string RandomPublicId()
        {
            var buffer = new byte[8];
            m_random.NextBytes(buffer);
            return string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
        }

        public RawUploadResult UploadLarge(RawUploadParams parameters, int bufferSize = 20971520)
        {
            return UploadLarge<RawUploadResult>(parameters, bufferSize);
        }

        public ImageUploadResult UploadLarge(ImageUploadParams parameters, int bufferSize = 20971520)
        {
            return UploadLarge<ImageUploadResult>(parameters, bufferSize);
        }

        public VideoUploadResult UploadLarge(VideoUploadParams parameters, int bufferSize = 20971520)
        {
            return UploadLarge<VideoUploadResult>(parameters, bufferSize);
        }

        [Obsolete("Use UploadLarge(parameters, bufferSize) instead.")]
        public UploadResult UploadLarge(BasicRawUploadParams parameters, int bufferSize = 20971520, bool isRaw = false)
        {
            if (isRaw)
                return UploadLarge<RawUploadResult>(parameters, bufferSize);
            return UploadLarge<ImageUploadResult>(parameters, bufferSize);
        }

        public T UploadLarge<T>(BasicRawUploadParams parameters, int bufferSize = 20971520) where T : UploadResult, new()
        {
            var apiUrlImgUpV = Api.ApiUrlImgUpV;
            apiUrlImgUpV.ResourceType(Enum.GetName(typeof(ResourceType), parameters.ResourceType).ToLower());
            var url = apiUrlImgUpV.BuildUrl();
            ResetInternalFileDescription(parameters.File, bufferSize);
            var extraHeaders = new Dictionary<string, string>();
            extraHeaders["X-Unique-Upload-Id"] = RandomPublicId();
            parameters.File.BufferLength = bufferSize;
            var fileLength = parameters.File.GetFileLength();
            var obj = default(T);
            while (!parameters.File.EOF)
            {
                var num = Math.Min(bufferSize, fileLength - parameters.File.BytesSent);
                var paramsDictionary = parameters.ToParamsDictionary();
                var str = string.Format("bytes {0}-{1}/{2}", parameters.File.BytesSent, parameters.File.BytesSent + num - 1L, fileLength);
                extraHeaders["Content-Range"] = str;
                using (var response = Api.Call(HttpMethod.POST, url, paramsDictionary, parameters.File, extraHeaders))
                {
                    obj = BaseResult.Parse<T>(response);
                    if (obj.StatusCode != HttpStatusCode.OK)
                        throw new WebException(string.Format("An error has occured while uploading file (status code: {0}). {1}", obj.StatusCode,
                            obj.Error != null ? obj.Error.Message : "Unknown error"));
                }
            }
            return obj;
        }

        public RenameResult Rename(string fromPublicId, string toPublicId, bool overwrite = false)
        {
            return Rename(new RenameParams(fromPublicId, toPublicId) {Overwrite = overwrite});
        }

        public RenameResult Rename(RenameParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("rename").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return RenameResult.Parse(response);
            }
        }

        public DeletionResult Destroy(DeletionParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.ResourceType(Api.GetCloudinaryParam(parameters.ResourceType)).Action("destroy").BuildUrl(), parameters.ToParamsDictionary(),
                    null, null))
            {
                return DeletionResult.Parse(response);
            }
        }

        public TextResult Text(string text)
        {
            return Text(new TextParams(text));
        }

        public TextResult Text(TextParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("text").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return TextResult.Parse(response);
            }
        }

        public TagResult Tag(TagParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("tags").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return TagResult.Parse(response);
            }
        }

        public ListResourceTypesResult ListResourceTypes()
        {
            using (var response = Api.Call(HttpMethod.GET, Api.ApiUrlV.Add("resources").BuildUrl(), null, null, null))
            {
                return ListResourceTypesResult.Parse(response);
            }
        }

        public ListResourcesResult ListResources(string nextCursor = null, bool tags = true, bool context = true, bool moderations = true)
        {
            return ListResources(new ListResourcesParams {NextCursor = nextCursor, Tags = tags, Context = context, Moderations = moderations});
        }

        public ListResourcesResult ListResourcesByType(string type, string nextCursor = null)
        {
            return ListResources(new ListResourcesParams {Type = type, NextCursor = nextCursor});
        }

        public ListResourcesResult ListResourcesByPrefix(string prefix, string type = "upload", string nextCursor = null)
        {
            var resourcesByPrefixParams = new ListResourcesByPrefixParams();
            resourcesByPrefixParams.Type = type;
            resourcesByPrefixParams.Prefix = prefix;
            resourcesByPrefixParams.NextCursor = nextCursor;
            return ListResources(resourcesByPrefixParams);
        }

        public ListResourcesResult ListResourcesByPrefix(string prefix, bool tags, bool context, bool moderations, string type = "upload", string nextCursor = null)
        {
            var resourcesByPrefixParams = new ListResourcesByPrefixParams();
            resourcesByPrefixParams.Tags = tags;
            resourcesByPrefixParams.Context = context;
            resourcesByPrefixParams.Moderations = moderations;
            resourcesByPrefixParams.Type = type;
            resourcesByPrefixParams.Prefix = prefix;
            resourcesByPrefixParams.NextCursor = nextCursor;
            return ListResources(resourcesByPrefixParams);
        }

        public ListResourcesResult ListResourcesByTag(string tag, string nextCursor = null)
        {
            var resourcesByTagParams = new ListResourcesByTagParams();
            resourcesByTagParams.Tag = tag;
            resourcesByTagParams.NextCursor = nextCursor;
            return ListResources(resourcesByTagParams);
        }

        public ListResourcesResult ListResourcesByPublicIds(IEnumerable<string> publicIds)
        {
            return ListResources(new ListSpecificResourcesParams {PublicIds = new List<string>(publicIds)});
        }

        public ListResourcesResult ListResourceByPublicIds(IEnumerable<string> publicIds, bool tags, bool context, bool moderations)
        {
            var specificResourcesParams = new ListSpecificResourcesParams();
            specificResourcesParams.PublicIds = new List<string>(publicIds);
            specificResourcesParams.Tags = tags;
            specificResourcesParams.Context = context;
            specificResourcesParams.Moderations = moderations;
            return ListResources(specificResourcesParams);
        }

        public ListResourcesResult ListResourcesByModerationStatus(string kind, ModerationStatus status, bool tags = true, bool context = true, bool moderations = true, string nextCursor = null)
        {
            var moderationParams = new ListResourcesByModerationParams();
            moderationParams.ModerationKind = kind;
            moderationParams.ModerationStatus = status;
            moderationParams.Tags = tags;
            moderationParams.Context = context;
            moderationParams.Moderations = moderations;
            moderationParams.NextCursor = nextCursor;
            return ListResources(moderationParams);
        }

        public ListResourcesResult ListResources(ListResourcesParams parameters)
        {
            var url = Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType));
            if (parameters is ListResourcesByTagParams)
            {
                var resourcesByTagParams = (ListResourcesByTagParams) parameters;
                if (!string.IsNullOrEmpty(resourcesByTagParams.Tag))
                    url.Add("tags").Add(resourcesByTagParams.Tag);
            }
            if (parameters is ListResourcesByModerationParams)
            {
                var moderationParams = (ListResourcesByModerationParams) parameters;
                if (!string.IsNullOrEmpty(moderationParams.ModerationKind))
                    url.Add("moderations").Add(moderationParams.ModerationKind).Add(Api.GetCloudinaryParam(moderationParams.ModerationStatus));
            }
            using (var response = Api.Call(HttpMethod.GET, new UrlBuilder(url.BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return ListResourcesResult.Parse(response);
            }
        }

        public ListTagsResult ListTags()
        {
            return ListTags(new ListTagsParams());
        }

        public ListTagsResult ListTagsByPrefix(string prefix)
        {
            return ListTags(new ListTagsParams {Prefix = prefix});
        }

        public ListTagsResult ListTags(ListTagsParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.GET,
                    new UrlBuilder(Api.ApiUrlV.ResourceType("tags").Add(Api.GetCloudinaryParam(parameters.ResourceType)).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return ListTagsResult.Parse(response);
            }
        }

        public ListTransformsResult ListTransformations()
        {
            return ListTransformations(new ListTransformsParams());
        }

        public ListTransformsResult ListTransformations(ListTransformsParams parameters)
        {
            using (var response = Api.Call(HttpMethod.GET, new UrlBuilder(Api.ApiUrlV.ResourceType("transformations").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return ListTransformsResult.Parse(response);
            }
        }

        public GetTransformResult GetTransform(string transform)
        {
            return GetTransform(new GetTransformParams {Transformation = transform});
        }

        public GetTransformResult GetTransform(GetTransformParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.GET,
                    new UrlBuilder(Api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return GetTransformResult.Parse(response);
            }
        }

        public GetResourceResult UpdateResource(string publicId, ModerationStatus moderationStatus)
        {
            return UpdateResource(new UpdateParams(publicId) {ModerationStatus = moderationStatus});
        }

        public GetResourceResult UpdateResource(UpdateParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.POST,
                    Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl(), parameters.ToParamsDictionary(),
                    null, null))
            {
                return GetResourceResult.Parse(response);
            }
        }

        public GetResourceResult GetResource(string publicId)
        {
            return GetResource(new GetResourceParams(publicId));
        }

        public GetResourceResult GetResource(GetResourceParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.GET,
                    new UrlBuilder(Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl(),
                        parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return GetResourceResult.Parse(response);
            }
        }

        public DelDerivedResResult DeleteDerivedResources(params string[] ids)
        {
            var parameters = new DelDerivedResParams();
            parameters.DerivedResources.AddRange(ids);
            return DeleteDerivedResources(parameters);
        }

        public DelDerivedResResult DeleteDerivedResources(DelDerivedResParams parameters)
        {
            using (var response = Api.Call(HttpMethod.DELETE, new UrlBuilder(Api.ApiUrlV.Add("derived_resources").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return DelDerivedResResult.Parse(response);
            }
        }

        public DelResResult DeleteResources(ResourceType type, params string[] publicIds)
        {
            var parameters = new DelResParams {ResourceType = type};
            parameters.PublicIds.AddRange(publicIds);
            return DeleteResources(parameters);
        }

        public DelResResult DeleteResources(params string[] publicIds)
        {
            var parameters = new DelResParams();
            parameters.PublicIds.AddRange(publicIds);
            return DeleteResources(parameters);
        }

        public DelResResult DeleteResourcesByPrefix(string prefix)
        {
            return DeleteResources(new DelResParams {Prefix = prefix});
        }

        public DelResResult DeleteResourcesByPrefix(string prefix, bool keepOriginal, string nextCursor)
        {
            return DeleteResources(new DelResParams {Prefix = prefix, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public DelResResult DeleteResourcesByTag(string tag)
        {
            return DeleteResources(new DelResParams {Tag = tag});
        }

        public DelResResult DeleteResourcesByTag(string tag, bool keepOriginal, string nextCursor)
        {
            return DeleteResources(new DelResParams {Tag = tag, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public DelResResult DeleteAllResources()
        {
            return DeleteResources(new DelResParams {All = true});
        }

        public DelResResult DeleteAllResources(bool keepOriginal, string nextCursor)
        {
            return DeleteResources(new DelResParams {All = true, KeepOriginal = keepOriginal, NextCursor = nextCursor});
        }

        public DelResResult DeleteResources(DelResParams parameters)
        {
            var url = Api.ApiUrlV.Add("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType));
            using (
                var response = Api.Call(HttpMethod.DELETE,
                    new UrlBuilder((string.IsNullOrEmpty(parameters.Tag) ? url.Add(parameters.Type) : url.Add("tags").Add(parameters.Tag)).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null,
                    null, null))
            {
                return DelResResult.Parse(response);
            }
        }

        public RestoreResult Restore(params string[] publicIds)
        {
            var parameters = new RestoreParams();
            parameters.PublicIds.AddRange(publicIds);
            return Restore(parameters);
        }

        public RestoreResult Restore(RestoreParams parameters)
        {
            using (
                var response = Api.Call(HttpMethod.POST, Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add("upload").Add("restore").BuildUrl(),
                    parameters.ToParamsDictionary(), null, null))
            {
                return RestoreResult.Parse(response);
            }
        }

        private string GetUploadMappingUrl()
        {
            return Api.ApiUrlV.ResourceType("upload_mappings").BuildUrl();
        }

        private string GetUploadMappingUrl(UploadMappingParams parameters)
        {
            return new UrlBuilder(GetUploadMappingUrl(), parameters.ToParamsDictionary()).ToString();
        }

        private UploadMappingResults CallUploadMappingsAPI(HttpMethod httpMethod, UploadMappingParams parameters)
        {
            SortedDictionary<string, object> parameters1 = null;
            string uploadMappingUrl;
            if (httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT)
            {
                uploadMappingUrl = GetUploadMappingUrl();
                if (parameters != null)
                    parameters1 = parameters.ToParamsDictionary();
            }
            else
            {
                uploadMappingUrl = GetUploadMappingUrl(parameters);
            }
            using (var response = Api.Call(httpMethod, uploadMappingUrl, parameters1, null, null))
            {
                return UploadMappingResults.Parse(response);
            }
        }

        public UploadMappingResults UploadMappings(UploadMappingParams parameters)
        {
            if (parameters == null)
                parameters = new UploadMappingParams();
            return CallUploadMappingsAPI(HttpMethod.GET, parameters);
        }

        public UploadMappingResults UploadMapping(string folder)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder must be specified.");
            return CallUploadMappingsAPI(HttpMethod.GET, new UploadMappingParams {Folder = folder});
        }

        public UploadMappingResults CreateUploadMapping(string folder, string template)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder property must be specified.");
            if (string.IsNullOrEmpty(template))
                throw new ArgumentException("Template must be specified.");
            return CallUploadMappingsAPI(HttpMethod.POST, new UploadMappingParams {Folder = folder, Template = template});
        }

        public UploadMappingResults UpdateUploadMapping(string folder, string newTemplate)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder must be specified.");
            if (string.IsNullOrEmpty(newTemplate))
                throw new ArgumentException("New Template name must be specified.");
            return CallUploadMappingsAPI(HttpMethod.PUT, new UploadMappingParams {Folder = folder, Template = newTemplate});
        }

        public UploadMappingResults DeleteUploadMapping()
        {
            return DeleteUploadMapping(string.Empty);
        }

        public UploadMappingResults DeleteUploadMapping(string folder)
        {
            var parameters = new UploadMappingParams();
            if (!string.IsNullOrEmpty(folder))
                parameters.Folder = folder;
            return CallUploadMappingsAPI(HttpMethod.DELETE, parameters);
        }

        public UpdateTransformResult UpdateTransform(UpdateTransformParams parameters)
        {
            using (var response = Api.Call(HttpMethod.PUT, Api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return UpdateTransformResult.Parse(response);
            }
        }

        public TransformResult CreateTransform(CreateTransformParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlV.ResourceType("transformations").Add(parameters.Name).BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return TransformResult.Parse(response);
            }
        }

        public TransformResult DeleteTransform(string transformName)
        {
            using (var response = Api.Call(HttpMethod.DELETE, Api.ApiUrlV.ResourceType("transformations").Add(transformName).BuildUrl(), null, null, null))
            {
                return TransformResult.Parse(response);
            }
        }

        public SpriteResult MakeSprite(SpriteParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("sprite").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return SpriteResult.Parse(response);
            }
        }

        public MultiResult Multi(MultiParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("multi").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return MultiResult.Parse(response);
            }
        }

        public ExplodeResult Explode(ExplodeParams parameters)
        {
            using (var response = Api.Call(HttpMethod.POST, Api.ApiUrlImgUpV.Action("explode").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return ExplodeResult.Parse(response);
            }
        }

        public ArchiveResult CreateArchive(ArchiveParams parameters)
        {
            var url1 = Api.ApiUrlV.ResourceType("image").Action("generate_archive");
            if (!string.IsNullOrEmpty(parameters.ResourceType()))
                url1.ResourceType(parameters.ResourceType());
            var url2 = url1.BuildUrl();
            parameters.Mode(ArchiveCallMode.Create);
            using (var response = Api.Call(HttpMethod.POST, url2, parameters.ToParamsDictionary(), null, null))
            {
                return ArchiveResult.Parse(response);
            }
        }

        public string DownloadArchiveUrl(ArchiveParams parameters)
        {
            parameters.Mode(ArchiveCallMode.Download);
            return GetDownloadUrl(new UrlBuilder(Api.ApiUrlV.ResourceType("image").Action("generate_archive").BuildUrl()), parameters.ToParamsDictionary());
        }

        public IHtmlContent GetCloudinaryJsConfig(bool directUpload = false, string dir = "")
        {
            if (string.IsNullOrEmpty(dir))
                dir = "/Scripts";
            var sb = new StringBuilder(1000);
            AppendScriptLine(sb, dir, "jquery.ui.widget.js");
            AppendScriptLine(sb, dir, "jquery.iframe-transport.js");
            AppendScriptLine(sb, dir, "jquery.fileupload.js");
            AppendScriptLine(sb, dir, "jquery.cloudinary.js");
            if (directUpload)
            {
                AppendScriptLine(sb, dir, "canvas-to-blob.min.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-image.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-process.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-validate.js");
                AppendScriptLine(sb, dir, "load-image.min.js");
            }
            var jobject = new JObject(new JProperty("cloud_name", Api.Account.Cloud), new JProperty("api_key", Api.Account.ApiKey), new JProperty("private_cdn", Api.UsePrivateCdn),
                new JProperty("cdn_subdomain", Api.CSubDomain));
            if (!string.IsNullOrEmpty(Api.PrivateCdn))
                jobject.Add("secure_distribution", Api.PrivateCdn);
            sb.AppendLine("<script type='text/javascript'>");
            sb.Append("$.cloudinary.config(");
            sb.Append(jobject);
            sb.AppendLine(");");
            sb.AppendLine("</script>");
            return new HtmlString(sb.ToString());
        }

        private static void AppendScriptLine(StringBuilder sb, string dir, string script)
        {
            sb.Append("<script src=\"");
            sb.Append(dir);
            if (!dir.EndsWith("/") && !dir.EndsWith("\\"))
                sb.Append("/");
            sb.Append(script);
            sb.AppendLine("\"></script>");
        }

        private string GetDownloadUrl(UrlBuilder builder, IDictionary<string, object> parameters)
        {
            Api.FinalizeUploadParameters(parameters);
            builder.SetParameters(parameters);
            return builder.ToString();
        }

        private static void ResetInternalFileDescription(FileDescription file, int bufferSize = 2147483647)
        {
            file.BufferLength = bufferSize;
            file.EOF = false;
            file.BytesSent = 0;
        }
    }
}