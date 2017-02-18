// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Cloudinary
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace CloudinaryDotNet
{
    public class Cloudinary
    {
        public const string CF_SHARED_CDN = "d3jpl91pxevbkh.cloudfront.net";
        public const string OLD_AKAMAI_SHARED_CDN = "cloudinary-a.akamaihd.net";
        public const string AKAMAI_SHARED_CDN = "res.cloudinary.com";
        public const string SHARED_CDN = "res.cloudinary.com";
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


        
        private async Task<UploadMappingResults> CallUploadMappingsApiAsync(HttpMethod httpMethod, UploadMappingParams parameters)
        {
            SortedDictionary<string, object> parameters1 = null;
            string uploadMappingUrl;
            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
            {
                uploadMappingUrl = GetUploadMappingUrl();
                if (parameters != null)
                    parameters1 = parameters.ToParamsDictionary();
            }
            else
            {
                uploadMappingUrl = GetUploadMappingUrl(parameters);
            }
            using (var response = await Api.CallAsync(httpMethod, uploadMappingUrl, parameters1, null, null))
            {
                return await UploadMappingResults.Parse(response);
            }
        }



        public async Task<ArchiveResult> CreateArchiveAsync(ArchiveParams parameters)
        {
            var url1 = Api.ApiUrlV.ResourceType("image").Action("generate_archive");
            if (!string.IsNullOrEmpty(parameters.ResourceType()))
                url1.ResourceType(parameters.ResourceType());
            var url2 = url1.BuildUrl();
            parameters.Mode(ArchiveCallMode.Create);
            using (var response = await Api.CallAsync(HttpMethod.Post, url2, parameters.ToParamsDictionary(), null, null))
            {
                return  await ArchiveResult.Parse(response);
            }
        }



        public async Task<TransformResult> CreateTransformAsync(CreateTransformParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlV.ResourceType("transformations").Add(parameters.Name).BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await TransformResult.Parse(response);
            }
        }



        public Task<UploadMappingResults> CreateUploadMappingAsync(string folder, string template)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder property must be specified.");
            if (string.IsNullOrEmpty(template))
                throw new ArgumentException("Template must be specified.");
            return CallUploadMappingsApiAsync(HttpMethod.Post, new UploadMappingParams { Folder = folder, Template = template });
        }



        public async Task<UploadPresetResult> CreateUploadPresetAsync(UploadPresetParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlV.Add("upload_presets").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await UploadPresetResult.Parse(response);
            }
        }



        public async Task<DelDerivedResResult> DeleteDerivedResourcesAsync(DelDerivedResParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Delete, new UrlBuilder(Api.ApiUrlV.Add("derived_resources").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await DelDerivedResResult.Parse(response);
            }
        }

        public async Task<DelResResult> DeleteResourcesAsync(DelResParams parameters)
        {
            var url = Api.ApiUrlV.Add("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType));
            using (
                var response = await Api.CallAsync(HttpMethod.Delete,
                    new UrlBuilder((string.IsNullOrEmpty(parameters.Tag) ? url.Add(parameters.Type) : url.Add("tags").Add(parameters.Tag)).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null,
                    null, null))
            {
                return await DelResResult.Parse(response);
            }
        }



        public async Task<TransformResult> DeleteTransformAsync(string transformName)
        {
            using (var response = await Api.CallAsync(HttpMethod.Delete, Api.ApiUrlV.ResourceType("transformations").Add(transformName).BuildUrl(), null, null, null))
            {
                return await TransformResult.Parse(response);
            }
        }


        public async Task<UploadMappingResults> DeleteUploadMappingAsync(string folder)
        {
            var parameters = new UploadMappingParams();
            if (!string.IsNullOrEmpty(folder))
                parameters.Folder = folder;
            return await CallUploadMappingsApiAsync(HttpMethod.Delete, parameters);
        }


        public async Task<DeleteUploadPresetResult> DeleteUploadPresetAsync(string name)
        {
            using (var response = await Api.CallAsync(HttpMethod.Delete, Api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), null, null, null))
            {
                return await DeleteUploadPresetResult.Parse(response);
            }
        }

        public async Task<DeletionResult> DestroyAsync(DeletionParams parameters)
        {
            using (
               var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.ResourceType(Api.GetCloudinaryParam(parameters.ResourceType)).Action("destroy").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await DeletionResult.Parse(response);
            }
        }

        public string DownloadArchiveUrl(ArchiveParams parameters)
        {
            parameters.Mode(ArchiveCallMode.Download);
            return GetDownloadUrl(new UrlBuilder(Api.ApiUrlV.ResourceType("image").Action("generate_archive").BuildUrl()), parameters.ToParamsDictionary());
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

        public async Task<ExplicitResult> ExplicitAsync(ExplicitParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("explicit").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await ExplicitResult.Parse(response);
            }
        }

        public async Task<ExplodeResult> ExplodeAsync(ExplodeParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("explode").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await ExplodeResult.Parse(response);
            }
        }

        private string GetDownloadUrl(UrlBuilder builder, IDictionary<string, object> parameters)
        {
            Api.FinalizeUploadParameters(parameters);
            builder.SetParameters(parameters);
            return builder.ToString();
        }




        public async Task<GetResourceResult> GetResourceAsync(GetResourceParams parameters)
        {
            using (
              var response = await Api.CallAsync(HttpMethod.Get,
                  new UrlBuilder(Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl(),
                      parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await GetResourceResult.Parse(response);
            }
        }

        public async Task<GetTransformResult> GetTransformAsync(GetTransformParams parameters)
        {
            using (
                var response = await Api.CallAsync(HttpMethod.Get,
                    new UrlBuilder(Api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await GetTransformResult.Parse(response);
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


        public async Task<GetUploadPresetResult> GetUploadPresetAsync(string name)
        {
            using (var response = await Api.CallAsync(HttpMethod.Get, Api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), null, null, null))
            {
                return await GetUploadPresetResult.Parse(response);
            }
        }

        public async Task<UsageResult> GetUsageAsync()
        {
            using (var response =  await Api.CallAsync(HttpMethod.Get, Api.ApiUrlV.Action("usage").BuildUrl(), null, null, null))
            {
                return await UsageResult.Parse(response);
            }
        }


        public async Task<ListResourcesResult> ListResourcesAsync(ListResourcesParams parameters)
        {
            var url = Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType));
            if (parameters is ListResourcesByTagParams)
            {
                var resourcesByTagParams = (ListResourcesByTagParams)parameters;
                if (!string.IsNullOrEmpty(resourcesByTagParams.Tag))
                    url.Add("tags").Add(resourcesByTagParams.Tag);
            }
            if (parameters is ListResourcesByModerationParams)
            {
                var moderationParams = (ListResourcesByModerationParams)parameters;
                if (!string.IsNullOrEmpty(moderationParams.ModerationKind))
                    url.Add("moderations").Add(moderationParams.ModerationKind).Add(Api.GetCloudinaryParam(moderationParams.ModerationStatus));
            }
            using (var response = await Api.CallAsync(HttpMethod.Get, new UrlBuilder(url.BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await ListResourcesResult.Parse(response);
            }
        }

        public async Task<ListResourceTypesResult> ListResourceTypesAsync()
        {
            using (var response = await Api.CallAsync(HttpMethod.Get, Api.ApiUrlV.Add("resources").BuildUrl(), null, null, null))
            {
                return await ListResourceTypesResult.Parse(response);
            }
        }


        public async Task<ListTagsResult> ListTagsAsync(ListTagsParams parameters)
        {
            using (
                var response = await Api.CallAsync(HttpMethod.Get,
                    new UrlBuilder(Api.ApiUrlV.ResourceType("tags").Add(Api.GetCloudinaryParam(parameters.ResourceType)).BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await ListTagsResult.Parse(response);
            }
        }




        public async Task<ListTransformsResult> ListTransformationsAsync(ListTransformsParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Get, new UrlBuilder(Api.ApiUrlV.ResourceType("transformations").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await ListTransformsResult.Parse(response);
            }
        }



        public async Task<ListUploadPresetsResult> ListUploadPresetsAsync(ListUploadPresetsParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Get, new UrlBuilder(Api.ApiUrlV.Add("upload_presets").BuildUrl(), parameters.ToParamsDictionary()).ToString(), null, null, null))
            {
                return await ListUploadPresetsResult.Parse(response);
            }
        }



        public async Task<SpriteResult> MakeSpriteAsync(SpriteParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("sprite").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await SpriteResult.Parse(response);
            }
        }


        public async Task<MultiResult> MultiAsync(MultiParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("multi").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await MultiResult.Parse(response);
            }
        }

        private string RandomPublicId()
        {
            var buffer = new byte[8];
            m_random.NextBytes(buffer);
            return string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
        }


        public async Task<RenameResult> RenameAsync(RenameParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("rename").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await RenameResult.Parse(response);
            }
        }

        private static void ResetInternalFileDescription(FileDescription file, int bufferSize = 2147483647)
        {
            file.BufferLength = bufferSize;
            file.EOF = false;
            file.BytesSent = 0;
        }


        public async Task<RestoreResult> RestoreAsync(RestoreParams parameters)
        {
            using (
                var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add("upload").Add("restore").BuildUrl(),
                    parameters.ToParamsDictionary(), null, null))
            {
                return await RestoreResult.Parse(response);
            }
        }



        public async Task<GetFoldersResult> RootFoldersAsync()
        {
            using (var response = await Api.CallAsync(HttpMethod.Get, Api.ApiUrlV.Add("folders").BuildUrl(), null, null, null))
            {
                return await GetFoldersResult.Parse(response);
            }
        }


        public async Task<GetFoldersResult> SubFoldersAsync(string folder)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("folder must be set! Please use RootFolders() to get list of folders in root!");
            using (var response = await Api.CallAsync(HttpMethod.Get, Api.ApiUrlV.Add("folders").Add(folder).BuildUrl(), null, null, null))
            {
                return await GetFoldersResult.Parse(response);
            }
        }


        public async Task<TagResult> TagAsync(TagParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("tags").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await TagResult.Parse(response);
            }
        }

        public async Task<TextResult> TextAsync(TextParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Post, Api.ApiUrlImgUpV.Action("text").BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await TextResult.Parse(response);
            }
        }


        public async Task<GetResourceResult> UpdateResourceAsync(UpdateParams parameters)
        {
            var url = Api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl();
            using (var response = await Api.CallAsync(HttpMethod.Post,url, parameters.ToParamsDictionary(),null, null))
            {
                return await GetResourceResult.Parse(response);
            }
        }

        public async Task<UpdateTransformResult> UpdateTransformAsync(UpdateTransformParams parameters)
        {
            using (var response = await Api.CallAsync(HttpMethod.Put, Api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), parameters.ToParamsDictionary(), null, null))
            {
                return await UpdateTransformResult.Parse(response);
            }
        }


        public async Task<UploadMappingResults> UpdateUploadMappingAsync(string folder, string newTemplate)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder must be specified.");
            if (string.IsNullOrEmpty(newTemplate))
                throw new ArgumentException("New Template name must be specified.");
            return await CallUploadMappingsApiAsync(HttpMethod.Put, new UploadMappingParams { Folder = folder, Template = newTemplate });
        }


        public async Task<UploadPresetResult> UpdateUploadPresetAsync(UploadPresetParams parameters)
        {
            var paramsDictionary = parameters.ToParamsDictionary();
            paramsDictionary.Remove("name");
            using (var response = await Api.CallAsync(HttpMethod.Put, Api.ApiUrlV.Add("upload_presets").Add(parameters.Name).BuildUrl(), paramsDictionary, null, null))
            {
                return await UploadPresetResult.Parse(response);
            }
        }



        public async Task<RawUploadResult> UploadAsync(string resourceType, IDictionary<string, object> parameters, FileDescription fileDescription)
        {
            var url = Api.ApiUrlV.Action("upload").ResourceType(resourceType).BuildUrl();
            ResetInternalFileDescription(fileDescription, int.MaxValue);
            if (parameters == null)
                parameters = new SortedDictionary<string, object>();
            if (!(parameters is SortedDictionary<string, object>))
                parameters = new SortedDictionary<string, object>(parameters);
            using (var response = await Api.CallAsync(HttpMethod.Post, url, (SortedDictionary<string, object>)parameters, fileDescription, null))
            {
                return await RawUploadResult.Parse(response);
            }
        }


        public async Task<RawUploadResult> UploadAsync(RawUploadParams parameters, string type = "auto")
        {
            var url = Api.ApiUrlImgUpV.ResourceType(type).BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = await Api.CallAsync(HttpMethod.Post, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return await RawUploadResult.Parse(response);
            }
        }

        public async Task<VideoUploadResult> UploadAsync(VideoUploadParams parameters)
        {
            var url = Api.ApiUrlVideoUpV.BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = await Api.CallAsync(HttpMethod.Post, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return await VideoUploadResult.Parse(response);
            }
        }

        public async Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters)
        {
            var url = Api.ApiUrlImgUpV.BuildUrl();
            ResetInternalFileDescription(parameters.File, int.MaxValue);
            using (var response = await Api.CallAsync(HttpMethod.Post, url, parameters.ToParamsDictionary(), parameters.File, null))
            {
                return await ImageUploadResult.Parse(response);
            }
        }

        public async Task<T> UploadLargeAsync<T>(BasicRawUploadParams parameters, int bufferSize = 20971520) where T : UploadResult, new()
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
                using (var response = await Api.CallAsync(HttpMethod.Post, url, paramsDictionary, parameters.File, extraHeaders))
                {
                    obj = await BaseResult.Parse<T>(response);
                    if (obj.StatusCode != HttpStatusCode.OK)
                        throw new CloudinaryException($"An error has occured while uploading file (status code: {obj.StatusCode}). {obj.Error?.Message ?? "Unkown error"}");
                }
            }
            return obj;
        }


        public Task<RawUploadResult> UploadLargeRawAsync(BasicRawUploadParams parameters, int bufferSize = 20971520)
        {
            return UploadLargeAsync<RawUploadResult>(parameters, bufferSize);
        }

        public async Task<UploadMappingResults> UploadMappingsAsync(UploadMappingParams parameters)
        {
            if (parameters == null)
                parameters = new UploadMappingParams();
            return await CallUploadMappingsApiAsync(HttpMethod.Get, parameters);
        }
    }
}