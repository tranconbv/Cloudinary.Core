// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Cloudinary
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using CloudinaryDotNet.Actions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace CloudinaryDotNet
{
  public class Cloudinary
  {
    private static Random m_random = new Random();
    public const string CF_SHARED_CDN = "d3jpl91pxevbkh.cloudfront.net";
    public const string OLD_AKAMAI_SHARED_CDN = "cloudinary-a.akamaihd.net";
    public const string AKAMAI_SHARED_CDN = "res.cloudinary.com";
    public const string SHARED_CDN = "res.cloudinary.com";
    private const string RESOURCE_TYPE_IMAGE = "image";
    private const string ACTION_GENERATE_ARCHIVE = "generate_archive";
    private Api m_api;

    public Api Api
    {
      get
      {
        return this.m_api;
      }
    }

    public Cloudinary()
    {
      this.m_api = new Api();
    }

    public Cloudinary(string cloudinaryUrl)
    {
      this.m_api = new Api(cloudinaryUrl);
    }

    public Cloudinary(Account account)
    {
      this.m_api = new Api(account);
    }

    public Task<RawUploadResult> UploadLargeRawAsync(BasicRawUploadParams parameters, int bufferSize = 20971520)
    {
      return Task.Factory.StartNew<RawUploadResult>((Func<object, RawUploadResult>) (o =>
      {
        Tuple<BasicRawUploadParams, int> tuple = (Tuple<BasicRawUploadParams, int>) o;
        return this.UploadLargeRaw(tuple.Item1, tuple.Item2);
      }), (object) new Tuple<BasicRawUploadParams, int>(parameters, bufferSize));
    }

    public Task<RawUploadResult> UploadAsync(RawUploadParams parameters, string type = "auto")
    {
      return Task.Factory.StartNew<RawUploadResult>((Func<object, RawUploadResult>) (o =>
      {
        Tuple<RawUploadParams, string> tuple = (Tuple<RawUploadParams, string>) o;
        return this.Upload(tuple.Item1, tuple.Item2);
      }), (object) new Tuple<RawUploadParams, string>(parameters, type));
    }

    public Task<ImageUploadResult> UploadAsync(ImageUploadParams parameters)
    {
      return this.CallAsync<ImageUploadParams, ImageUploadResult>(new Func<ImageUploadParams, ImageUploadResult>(this.Upload), parameters);
    }

    public Task<ExplicitResult> ExplicitAsync(ExplicitParams parameters)
    {
      return this.CallAsync<ExplicitParams, ExplicitResult>(new Func<ExplicitParams, ExplicitResult>(this.Explicit), parameters);
    }

    public Task<RenameResult> RenameAsync(RenameParams parameters)
    {
      return this.CallAsync<RenameParams, RenameResult>(new Func<RenameParams, RenameResult>(this.Rename), parameters);
    }

    public Task<DeletionResult> DestroyAsync(DeletionParams parameters)
    {
      return this.CallAsync<DeletionParams, DeletionResult>(new Func<DeletionParams, DeletionResult>(this.Destroy), parameters);
    }

    public Task<TextResult> TextAsync(TextParams parameters)
    {
      return this.CallAsync<TextParams, TextResult>(new Func<TextParams, TextResult>(this.Text), parameters);
    }

    public Task<TagResult> TagAsync(TagParams parameters)
    {
      return this.CallAsync<TagParams, TagResult>(new Func<TagParams, TagResult>(this.Tag), parameters);
    }

    public Task<ListResourcesResult> ListResourcesAsync(ListResourcesParams parameters)
    {
      return this.CallAsync<ListResourcesParams, ListResourcesResult>(new Func<ListResourcesParams, ListResourcesResult>(this.ListResources), parameters);
    }

    public Task<ListTagsResult> ListTagsAsync(ListTagsParams parameters)
    {
      return this.CallAsync<ListTagsParams, ListTagsResult>(new Func<ListTagsParams, ListTagsResult>(this.ListTags), parameters);
    }

    public Task<ListTransformsResult> ListTransformationsAsync(ListTransformsParams parameters)
    {
      return this.CallAsync<ListTransformsParams, ListTransformsResult>(new Func<ListTransformsParams, ListTransformsResult>(this.ListTransformations), parameters);
    }

    public Task<GetTransformResult> GetTransformAsync(GetTransformParams parameters)
    {
      return this.CallAsync<GetTransformParams, GetTransformResult>(new Func<GetTransformParams, GetTransformResult>(this.GetTransform), parameters);
    }

    public Task<GetResourceResult> UpdateResourceAsync(UpdateParams parameters)
    {
      return this.CallAsync<UpdateParams, GetResourceResult>(new Func<UpdateParams, GetResourceResult>(this.UpdateResource), parameters);
    }

    public Task<GetResourceResult> GetResourceAsync(GetResourceParams parameters)
    {
      return this.CallAsync<GetResourceParams, GetResourceResult>(new Func<GetResourceParams, GetResourceResult>(this.GetResource), parameters);
    }

    public Task<DelDerivedResResult> DeleteDerivedResourcesAsync(DelDerivedResParams parameters)
    {
      return this.CallAsync<DelDerivedResParams, DelDerivedResResult>(new Func<DelDerivedResParams, DelDerivedResResult>(this.DeleteDerivedResources), parameters);
    }

    public Task<DelResResult> DeleteResourcesAsync(DelResParams parameters)
    {
      return this.CallAsync<DelResParams, DelResResult>(new Func<DelResParams, DelResResult>(this.DeleteResources), parameters);
    }

    public Task<UpdateTransformResult> UpdateTransformAsync(UpdateTransformParams parameters)
    {
      return this.CallAsync<UpdateTransformParams, UpdateTransformResult>(new Func<UpdateTransformParams, UpdateTransformResult>(this.UpdateTransform), parameters);
    }

    public Task<TransformResult> CreateTransformAsync(CreateTransformParams parameters)
    {
      return this.CallAsync<CreateTransformParams, TransformResult>(new Func<CreateTransformParams, TransformResult>(this.CreateTransform), parameters);
    }

    public Task<SpriteResult> MakeSpriteAsync(SpriteParams parameters)
    {
      return this.CallAsync<SpriteParams, SpriteResult>(new Func<SpriteParams, SpriteResult>(this.MakeSprite), parameters);
    }

    public Task<MultiResult> MultiAsync(MultiParams parameters)
    {
      return this.CallAsync<MultiParams, MultiResult>(new Func<MultiParams, MultiResult>(this.Multi), parameters);
    }

    public Task<ExplodeResult> ExplodeAsync(ExplodeParams parameters)
    {
      return this.CallAsync<ExplodeParams, ExplodeResult>(new Func<ExplodeParams, ExplodeResult>(this.Explode), parameters);
    }

    public Task<UsageResult> GetUsageAsync()
    {
      return Task.Factory.StartNew<UsageResult>(new Func<UsageResult>(this.GetUsage));
    }

    private Task<TRes> CallAsync<TParams, TRes>(Func<TParams, TRes> f, TParams @params)
    {
      return Task.Factory.StartNew<TRes>((Func<object, TRes>) (o => f(@params)), (object) @params);
    }

    public ExplicitResult Explicit(ExplicitParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("explicit").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return ExplicitResult.Parse(response);
    }

    public UploadPresetResult CreateUploadPreset(UploadPresetParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlV.Add("upload_presets").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return UploadPresetResult.Parse(response);
    }

    public UploadPresetResult UpdateUploadPreset(UploadPresetParams parameters)
    {
      SortedDictionary<string, object> paramsDictionary = parameters.ToParamsDictionary();
      paramsDictionary.Remove("name");
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.PUT, this.m_api.ApiUrlV.Add("upload_presets").Add(parameters.Name).BuildUrl(), paramsDictionary, (FileDescription) null, (Dictionary<string, string>) null))
        return UploadPresetResult.Parse(response);
    }

    public GetUploadPresetResult GetUploadPreset(string name)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, this.m_api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return GetUploadPresetResult.Parse(response);
    }

    public ListUploadPresetsResult ListUploadPresets(string nextCursor = null)
    {
      return this.ListUploadPresets(new ListUploadPresetsParams() { NextCursor = nextCursor });
    }

    public ListUploadPresetsResult ListUploadPresets(ListUploadPresetsParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(this.m_api.ApiUrlV.Add("upload_presets").BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return ListUploadPresetsResult.Parse(response);
    }

    public DeleteUploadPresetResult DeleteUploadPreset(string name)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.DELETE, this.m_api.ApiUrlV.Add("upload_presets").Add(name).BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return DeleteUploadPresetResult.Parse(response);
    }

    public ImageUploadResult Upload(ImageUploadParams parameters)
    {
      string url = this.m_api.ApiUrlImgUpV.BuildUrl();
      Cloudinary.ResetInternalFileDescription(parameters.File, int.MaxValue);
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, (Dictionary<string, string>) null))
        return ImageUploadResult.Parse(response);
    }

    public VideoUploadResult Upload(VideoUploadParams parameters)
    {
      string url = this.m_api.ApiUrlVideoUpV.BuildUrl();
      Cloudinary.ResetInternalFileDescription(parameters.File, int.MaxValue);
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, (Dictionary<string, string>) null))
        return VideoUploadResult.Parse(response);
    }

    public RawUploadResult Upload(string resourceType, IDictionary<string, object> parameters, FileDescription fileDescription)
    {
      string url = this.m_api.ApiUrlV.Action("upload").ResourceType(resourceType).BuildUrl();
      Cloudinary.ResetInternalFileDescription(fileDescription, int.MaxValue);
      if (parameters == null)
        parameters = (IDictionary<string, object>) new SortedDictionary<string, object>();
      if (!(parameters is SortedDictionary<string, object>))
        parameters = (IDictionary<string, object>) new SortedDictionary<string, object>(parameters);
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url, (SortedDictionary<string, object>) parameters, fileDescription, (Dictionary<string, string>) null))
        return RawUploadResult.Parse(response);
    }

    public GetFoldersResult RootFolders()
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, this.m_api.ApiUrlV.Add("folders").BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return GetFoldersResult.Parse(response);
    }

    public GetFoldersResult SubFolders(string folder)
    {
      if (string.IsNullOrEmpty(folder))
        throw new ArgumentException("folder must be set! Please use RootFolders() to get list of folders in root!");
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, this.m_api.ApiUrlV.Add("folders").Add(folder).BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return GetFoldersResult.Parse(response);
    }

    public string DownloadPrivate(string publicId, bool? attachment = null, string format = "", string type = "")
    {
      if (string.IsNullOrEmpty(publicId))
        throw new ArgumentException("publicId");
      UrlBuilder builder = new UrlBuilder(this.m_api.ApiUrlV.ResourceType("image").Action("download").BuildUrl());
      SortedDictionary<string, object> sortedDictionary = new SortedDictionary<string, object>();
      sortedDictionary.Add("public_id", (object) publicId);
      if (!string.IsNullOrEmpty(format))
        sortedDictionary.Add("format", (object) format);
      if (attachment.HasValue)
        sortedDictionary.Add("attachment", attachment.Value ? (object) "true" : (object) "false");
      if (!string.IsNullOrEmpty(type))
        sortedDictionary.Add("type", (object) type);
      return this.GetDownloadUrl(builder, (IDictionary<string, object>) sortedDictionary);
    }

    public string DownloadZip(string tag, Transformation transform)
    {
      if (string.IsNullOrEmpty(tag))
        throw new ArgumentException("Tag should be specified!");
      UrlBuilder builder = new UrlBuilder(this.m_api.ApiUrlV.ResourceType("image").Action("download_tag.zip").BuildUrl());
      SortedDictionary<string, object> sortedDictionary = new SortedDictionary<string, object>();
      sortedDictionary.Add("tag", (object) tag);
      if (transform != null)
        sortedDictionary.Add("transformation", (object) transform.Generate());
      return this.GetDownloadUrl(builder, (IDictionary<string, object>) sortedDictionary);
    }

    public UsageResult GetUsage()
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, this.m_api.ApiUrlV.Action("usage").BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return UsageResult.Parse(response);
    }

    public RawUploadResult Upload(RawUploadParams parameters, string type = "auto")
    {
      string url = this.m_api.ApiUrlImgUpV.ResourceType(type).BuildUrl();
      Cloudinary.ResetInternalFileDescription(parameters.File, int.MaxValue);
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url, parameters.ToParamsDictionary(), parameters.File, (Dictionary<string, string>) null))
        return RawUploadResult.Parse(response);
    }

    public RawUploadResult UploadLargeRaw(BasicRawUploadParams parameters, int bufferSize = 20971520)
    {
      if (parameters is RawUploadParams)
        throw new ArgumentException("Please use BasicRawUploadParams class for large raw file uploading!");
      parameters.Check();
      if (parameters.File.IsRemote)
        throw new ArgumentException("The UploadLargeRaw method is intended to be used for large local file uploading and can't be used for remote file uploading!");
      return this.UploadLarge(parameters, bufferSize, true) as RawUploadResult;
    }

    private string RandomPublicId()
    {
      byte[] buffer = new byte[8];
      Cloudinary.m_random.NextBytes(buffer);
      return string.Concat(((IEnumerable<byte>) buffer).Select<byte, string>((Func<byte, string>) (x => x.ToString("X2"))).ToArray<string>());
    }

    public RawUploadResult UploadLarge(RawUploadParams parameters, int bufferSize = 20971520)
    {
      return this.UploadLarge<RawUploadResult>((BasicRawUploadParams) parameters, bufferSize);
    }

    public ImageUploadResult UploadLarge(ImageUploadParams parameters, int bufferSize = 20971520)
    {
      return this.UploadLarge<ImageUploadResult>((BasicRawUploadParams) parameters, bufferSize);
    }

    public VideoUploadResult UploadLarge(VideoUploadParams parameters, int bufferSize = 20971520)
    {
      return this.UploadLarge<VideoUploadResult>((BasicRawUploadParams) parameters, bufferSize);
    }

    [Obsolete("Use UploadLarge(parameters, bufferSize) instead.")]
    public UploadResult UploadLarge(BasicRawUploadParams parameters, int bufferSize = 20971520, bool isRaw = false)
    {
      if (isRaw)
        return (UploadResult) this.UploadLarge<RawUploadResult>(parameters, bufferSize);
      return (UploadResult) this.UploadLarge<ImageUploadResult>(parameters, bufferSize);
    }

    public T UploadLarge<T>(BasicRawUploadParams parameters, int bufferSize = 20971520) where T : UploadResult, new()
    {
      Url apiUrlImgUpV = this.m_api.ApiUrlImgUpV;
      apiUrlImgUpV.ResourceType(Enum.GetName(typeof (ResourceType), (object) parameters.ResourceType).ToLower());
      string url = apiUrlImgUpV.BuildUrl();
      Cloudinary.ResetInternalFileDescription(parameters.File, bufferSize);
      Dictionary<string, string> extraHeaders = new Dictionary<string, string>();
      extraHeaders["X-Unique-Upload-Id"] = this.RandomPublicId();
      parameters.File.BufferLength = bufferSize;
      long fileLength = parameters.File.GetFileLength();
      T obj = default (T);
      while (!parameters.File.EOF)
      {
        long num = Math.Min((long) bufferSize, fileLength - (long) parameters.File.BytesSent);
        SortedDictionary<string, object> paramsDictionary = parameters.ToParamsDictionary();
        string str = string.Format("bytes {0}-{1}/{2}", (object) parameters.File.BytesSent, (object) ((long) parameters.File.BytesSent + num - 1L), (object) fileLength);
        extraHeaders["Content-Range"] = str;
        using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url, paramsDictionary, parameters.File, extraHeaders))
        {
          obj = BaseResult.Parse<T>(response);
          if (obj.StatusCode != HttpStatusCode.OK)
            throw new WebException(string.Format("An error has occured while uploading file (status code: {0}). {1}", (object) obj.StatusCode, obj.Error != null ? (object) obj.Error.Message : (object) "Unknown error"));
        }
      }
      return obj;
    }

    public RenameResult Rename(string fromPublicId, string toPublicId, bool overwrite = false)
    {
      return this.Rename(new RenameParams(fromPublicId, toPublicId) { Overwrite = overwrite });
    }

    public RenameResult Rename(RenameParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("rename").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return RenameResult.Parse(response);
    }

    public DeletionResult Destroy(DeletionParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.ResourceType(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType)).Action("destroy").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return DeletionResult.Parse(response);
    }

    public TextResult Text(string text)
    {
      return this.Text(new TextParams(text));
    }

    public TextResult Text(TextParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("text").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return TextResult.Parse(response);
    }

    public TagResult Tag(TagParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("tags").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return TagResult.Parse(response);
    }

    public ListResourceTypesResult ListResourceTypes()
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, this.m_api.ApiUrlV.Add("resources").BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return ListResourceTypesResult.Parse(response);
    }

    public ListResourcesResult ListResources(string nextCursor = null, bool tags = true, bool context = true, bool moderations = true)
    {
      return this.ListResources(new ListResourcesParams() { NextCursor = nextCursor, Tags = tags, Context = context, Moderations = moderations });
    }

    public ListResourcesResult ListResourcesByType(string type, string nextCursor = null)
    {
      return this.ListResources(new ListResourcesParams() { Type = type, NextCursor = nextCursor });
    }

    public ListResourcesResult ListResourcesByPrefix(string prefix, string type = "upload", string nextCursor = null)
    {
      ListResourcesByPrefixParams resourcesByPrefixParams = new ListResourcesByPrefixParams();
      resourcesByPrefixParams.Type = type;
      resourcesByPrefixParams.Prefix = prefix;
      resourcesByPrefixParams.NextCursor = nextCursor;
      return this.ListResources((ListResourcesParams) resourcesByPrefixParams);
    }

    public ListResourcesResult ListResourcesByPrefix(string prefix, bool tags, bool context, bool moderations, string type = "upload", string nextCursor = null)
    {
      ListResourcesByPrefixParams resourcesByPrefixParams = new ListResourcesByPrefixParams();
      resourcesByPrefixParams.Tags = tags;
      resourcesByPrefixParams.Context = context;
      resourcesByPrefixParams.Moderations = moderations;
      resourcesByPrefixParams.Type = type;
      resourcesByPrefixParams.Prefix = prefix;
      resourcesByPrefixParams.NextCursor = nextCursor;
      return this.ListResources((ListResourcesParams) resourcesByPrefixParams);
    }

    public ListResourcesResult ListResourcesByTag(string tag, string nextCursor = null)
    {
      ListResourcesByTagParams resourcesByTagParams = new ListResourcesByTagParams();
      resourcesByTagParams.Tag = tag;
      resourcesByTagParams.NextCursor = nextCursor;
      return this.ListResources((ListResourcesParams) resourcesByTagParams);
    }

    public ListResourcesResult ListResourcesByPublicIds(IEnumerable<string> publicIds)
    {
      return this.ListResources((ListResourcesParams) new ListSpecificResourcesParams() { PublicIds = new List<string>(publicIds) });
    }

    public ListResourcesResult ListResourceByPublicIds(IEnumerable<string> publicIds, bool tags, bool context, bool moderations)
    {
      ListSpecificResourcesParams specificResourcesParams = new ListSpecificResourcesParams();
      specificResourcesParams.PublicIds = new List<string>(publicIds);
      specificResourcesParams.Tags = tags;
      specificResourcesParams.Context = context;
      specificResourcesParams.Moderations = moderations;
      return this.ListResources((ListResourcesParams) specificResourcesParams);
    }

    public ListResourcesResult ListResourcesByModerationStatus(string kind, ModerationStatus status, bool tags = true, bool context = true, bool moderations = true, string nextCursor = null)
    {
      ListResourcesByModerationParams moderationParams = new ListResourcesByModerationParams();
      moderationParams.ModerationKind = kind;
      moderationParams.ModerationStatus = status;
      moderationParams.Tags = tags;
      moderationParams.Context = context;
      moderationParams.Moderations = moderations;
      moderationParams.NextCursor = nextCursor;
      return this.ListResources((ListResourcesParams) moderationParams);
    }

    public ListResourcesResult ListResources(ListResourcesParams parameters)
    {
      Url url = this.m_api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType));
      if (parameters is ListResourcesByTagParams)
      {
        ListResourcesByTagParams resourcesByTagParams = (ListResourcesByTagParams) parameters;
        if (!string.IsNullOrEmpty(resourcesByTagParams.Tag))
          url.Add("tags").Add(resourcesByTagParams.Tag);
      }
      if (parameters is ListResourcesByModerationParams)
      {
        ListResourcesByModerationParams moderationParams = (ListResourcesByModerationParams) parameters;
        if (!string.IsNullOrEmpty(moderationParams.ModerationKind))
          url.Add("moderations").Add(moderationParams.ModerationKind).Add(Api.GetCloudinaryParam<ModerationStatus>(moderationParams.ModerationStatus));
      }
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(url.BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return ListResourcesResult.Parse(response);
    }

    public ListTagsResult ListTags()
    {
      return this.ListTags(new ListTagsParams());
    }

    public ListTagsResult ListTagsByPrefix(string prefix)
    {
      return this.ListTags(new ListTagsParams() { Prefix = prefix });
    }

    public ListTagsResult ListTags(ListTagsParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(this.m_api.ApiUrlV.ResourceType("tags").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType)).BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return ListTagsResult.Parse(response);
    }

    public ListTransformsResult ListTransformations()
    {
      return this.ListTransformations(new ListTransformsParams());
    }

    public ListTransformsResult ListTransformations(ListTransformsParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(this.m_api.ApiUrlV.ResourceType("transformations").BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return ListTransformsResult.Parse(response);
    }

    public GetTransformResult GetTransform(string transform)
    {
      return this.GetTransform(new GetTransformParams() { Transformation = transform });
    }

    public GetTransformResult GetTransform(GetTransformParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(this.m_api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return GetTransformResult.Parse(response);
    }

    public GetResourceResult UpdateResource(string publicId, ModerationStatus moderationStatus)
    {
      return this.UpdateResource(new UpdateParams(publicId) { ModerationStatus = moderationStatus });
    }

    public GetResourceResult UpdateResource(UpdateParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return GetResourceResult.Parse(response);
    }

    public GetResourceResult GetResource(string publicId)
    {
      return this.GetResource(new GetResourceParams(publicId));
    }

    public GetResourceResult GetResource(GetResourceParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.GET, new UrlBuilder(this.m_api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType)).Add(parameters.Type).Add(parameters.PublicId).BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return GetResourceResult.Parse(response);
    }

    public DelDerivedResResult DeleteDerivedResources(params string[] ids)
    {
      DelDerivedResParams parameters = new DelDerivedResParams();
      parameters.DerivedResources.AddRange((IEnumerable<string>) ids);
      return this.DeleteDerivedResources(parameters);
    }

    public DelDerivedResResult DeleteDerivedResources(DelDerivedResParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.DELETE, new UrlBuilder(this.m_api.ApiUrlV.Add("derived_resources").BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return DelDerivedResResult.Parse(response);
    }

    public DelResResult DeleteResources(ResourceType type, params string[] publicIds)
    {
      DelResParams parameters = new DelResParams() { ResourceType = type };
      parameters.PublicIds.AddRange((IEnumerable<string>) publicIds);
      return this.DeleteResources(parameters);
    }

    public DelResResult DeleteResources(params string[] publicIds)
    {
      DelResParams parameters = new DelResParams();
      parameters.PublicIds.AddRange((IEnumerable<string>) publicIds);
      return this.DeleteResources(parameters);
    }

    public DelResResult DeleteResourcesByPrefix(string prefix)
    {
      return this.DeleteResources(new DelResParams() { Prefix = prefix });
    }

    public DelResResult DeleteResourcesByPrefix(string prefix, bool keepOriginal, string nextCursor)
    {
      return this.DeleteResources(new DelResParams() { Prefix = prefix, KeepOriginal = keepOriginal, NextCursor = nextCursor });
    }

    public DelResResult DeleteResourcesByTag(string tag)
    {
      return this.DeleteResources(new DelResParams() { Tag = tag });
    }

    public DelResResult DeleteResourcesByTag(string tag, bool keepOriginal, string nextCursor)
    {
      return this.DeleteResources(new DelResParams() { Tag = tag, KeepOriginal = keepOriginal, NextCursor = nextCursor });
    }

    public DelResResult DeleteAllResources()
    {
      return this.DeleteResources(new DelResParams() { All = true });
    }

    public DelResResult DeleteAllResources(bool keepOriginal, string nextCursor)
    {
      return this.DeleteResources(new DelResParams() { All = true, KeepOriginal = keepOriginal, NextCursor = nextCursor });
    }

    public DelResResult DeleteResources(DelResParams parameters)
    {
      Url url = this.m_api.ApiUrlV.Add("resources").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType));
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.DELETE, new UrlBuilder((string.IsNullOrEmpty(parameters.Tag) ? url.Add(parameters.Type) : url.Add("tags").Add(parameters.Tag)).BuildUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return DelResResult.Parse(response);
    }

    public RestoreResult Restore(params string[] publicIds)
    {
      RestoreParams parameters = new RestoreParams();
      parameters.PublicIds.AddRange((IEnumerable<string>) publicIds);
      return this.Restore(parameters);
    }

    public RestoreResult Restore(RestoreParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlV.ResourceType("resources").Add(Api.GetCloudinaryParam<ResourceType>(parameters.ResourceType)).Add("upload").Add("restore").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return RestoreResult.Parse(response);
    }

    private string GetUploadMappingUrl()
    {
      return this.m_api.ApiUrlV.ResourceType("upload_mappings").BuildUrl();
    }

    private string GetUploadMappingUrl(UploadMappingParams parameters)
    {
      return new UrlBuilder(this.GetUploadMappingUrl(), (IDictionary<string, object>) parameters.ToParamsDictionary()).ToString();
    }

    private UploadMappingResults CallUploadMappingsAPI(HttpMethod httpMethod, UploadMappingParams parameters)
    {
      SortedDictionary<string, object> parameters1 = (SortedDictionary<string, object>) null;
      string uploadMappingUrl;
      if (httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT)
      {
        uploadMappingUrl = this.GetUploadMappingUrl();
        if (parameters != null)
          parameters1 = parameters.ToParamsDictionary();
      }
      else
        uploadMappingUrl = this.GetUploadMappingUrl(parameters);
      using (HttpWebResponse response = this.m_api.Call(httpMethod, uploadMappingUrl, parameters1, (FileDescription) null, (Dictionary<string, string>) null))
        return UploadMappingResults.Parse(response);
    }

    public UploadMappingResults UploadMappings(UploadMappingParams parameters)
    {
      if (parameters == null)
        parameters = new UploadMappingParams();
      return this.CallUploadMappingsAPI(HttpMethod.GET, parameters);
    }

    public UploadMappingResults UploadMapping(string folder)
    {
      if (string.IsNullOrEmpty(folder))
        throw new ArgumentException("Folder must be specified.");
      return this.CallUploadMappingsAPI(HttpMethod.GET, new UploadMappingParams() { Folder = folder });
    }

    public UploadMappingResults CreateUploadMapping(string folder, string template)
    {
      if (string.IsNullOrEmpty(folder))
        throw new ArgumentException("Folder property must be specified.");
      if (string.IsNullOrEmpty(template))
        throw new ArgumentException("Template must be specified.");
      return this.CallUploadMappingsAPI(HttpMethod.POST, new UploadMappingParams() { Folder = folder, Template = template });
    }

    public UploadMappingResults UpdateUploadMapping(string folder, string newTemplate)
    {
      if (string.IsNullOrEmpty(folder))
        throw new ArgumentException("Folder must be specified.");
      if (string.IsNullOrEmpty(newTemplate))
        throw new ArgumentException("New Template name must be specified.");
      return this.CallUploadMappingsAPI(HttpMethod.PUT, new UploadMappingParams() { Folder = folder, Template = newTemplate });
    }

    public UploadMappingResults DeleteUploadMapping()
    {
      return this.DeleteUploadMapping(string.Empty);
    }

    public UploadMappingResults DeleteUploadMapping(string folder)
    {
      UploadMappingParams parameters = new UploadMappingParams();
      if (!string.IsNullOrEmpty(folder))
        parameters.Folder = folder;
      return this.CallUploadMappingsAPI(HttpMethod.DELETE, parameters);
    }

    public UpdateTransformResult UpdateTransform(UpdateTransformParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.PUT, this.m_api.ApiUrlV.ResourceType("transformations").Add(parameters.Transformation).BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return UpdateTransformResult.Parse(response);
    }

    public TransformResult CreateTransform(CreateTransformParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlV.ResourceType("transformations").Add(parameters.Name).BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return TransformResult.Parse(response);
    }

    public TransformResult DeleteTransform(string transformName)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.DELETE, this.m_api.ApiUrlV.ResourceType("transformations").Add(transformName).BuildUrl(), (SortedDictionary<string, object>) null, (FileDescription) null, (Dictionary<string, string>) null))
        return TransformResult.Parse(response);
    }

    public SpriteResult MakeSprite(SpriteParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("sprite").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return SpriteResult.Parse(response);
    }

    public MultiResult Multi(MultiParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("multi").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return MultiResult.Parse(response);
    }

    public ExplodeResult Explode(ExplodeParams parameters)
    {
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, this.m_api.ApiUrlImgUpV.Action("explode").BuildUrl(), parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return ExplodeResult.Parse(response);
    }

    public ArchiveResult CreateArchive(ArchiveParams parameters)
    {
      Url url1 = this.m_api.ApiUrlV.ResourceType("image").Action("generate_archive");
      if (!string.IsNullOrEmpty(parameters.ResourceType()))
        url1.ResourceType(parameters.ResourceType());
      string url2 = url1.BuildUrl();
      parameters.Mode(ArchiveCallMode.Create);
      using (HttpWebResponse response = this.m_api.Call(HttpMethod.POST, url2, parameters.ToParamsDictionary(), (FileDescription) null, (Dictionary<string, string>) null))
        return ArchiveResult.Parse(response);
    }

    public string DownloadArchiveUrl(ArchiveParams parameters)
    {
      parameters.Mode(ArchiveCallMode.Download);
      return this.GetDownloadUrl(new UrlBuilder(this.m_api.ApiUrlV.ResourceType("image").Action("generate_archive").BuildUrl()), (IDictionary<string, object>) parameters.ToParamsDictionary());
    }

    public IHtmlContent GetCloudinaryJsConfig(bool directUpload = false, string dir = "")
    {
      if (string.IsNullOrEmpty(dir))
        dir = "/Scripts";
      StringBuilder sb = new StringBuilder(1000);
      Cloudinary.AppendScriptLine(sb, dir, "jquery.ui.widget.js");
      Cloudinary.AppendScriptLine(sb, dir, "jquery.iframe-transport.js");
      Cloudinary.AppendScriptLine(sb, dir, "jquery.fileupload.js");
      Cloudinary.AppendScriptLine(sb, dir, "jquery.cloudinary.js");
      if (directUpload)
      {
        Cloudinary.AppendScriptLine(sb, dir, "canvas-to-blob.min.js");
        Cloudinary.AppendScriptLine(sb, dir, "jquery.fileupload-image.js");
        Cloudinary.AppendScriptLine(sb, dir, "jquery.fileupload-process.js");
        Cloudinary.AppendScriptLine(sb, dir, "jquery.fileupload-validate.js");
        Cloudinary.AppendScriptLine(sb, dir, "load-image.min.js");
      }
      JObject jobject = new JObject((object[]) new JProperty[4]{ new JProperty("cloud_name", (object) this.m_api.Account.Cloud), new JProperty("api_key", (object) this.m_api.Account.ApiKey), new JProperty("private_cdn", (object) this.m_api.UsePrivateCdn), new JProperty("cdn_subdomain", (object) this.m_api.CSubDomain) });
      if (!string.IsNullOrEmpty(this.m_api.PrivateCdn))
        jobject.Add("secure_distribution", (JToken) this.m_api.PrivateCdn);
      sb.AppendLine("<script type='text/javascript'>");
      sb.Append("$.cloudinary.config(");
      sb.Append(jobject.ToString());
      sb.AppendLine(");");
      sb.AppendLine("</script>");
      return (IHtmlContent) new HtmlString(sb.ToString());
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
      this.m_api.FinalizeUploadParameters(parameters);
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
