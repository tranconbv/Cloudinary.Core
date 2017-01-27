// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ArchiveParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet.Actions
{
  public class ArchiveParams : BaseParams
  {
    private ArchiveCallMode m_mode = ArchiveCallMode.Create;
    private List<string> m_publicIds;
    private List<string> m_tags;
    private List<string> m_prefixes;
    private string m_resourceType;
    private string m_type;
    private List<Transformation> m_transformations;
    private ArchiveFormat m_targetFormat;
    private bool m_flattenFolders;
    private bool m_flattenTransformations;
    private int m_expiresAt;
    private bool m_useOriginalFilename;
    private string m_notificationUrl;
    private bool m_keepDerived;
    private string m_targetPublicId;
    private bool m_async;
    private List<string> m_targetTags;

    public List<string> PublicIds()
    {
      return this.m_publicIds;
    }

    public ArchiveParams PublicIds(List<string> publicIds)
    {
      this.m_publicIds = publicIds;
      return this;
    }

    public List<string> Tags()
    {
      return this.m_tags;
    }

    public ArchiveParams Tags(List<string> tags)
    {
      this.m_tags = tags;
      return this;
    }

    public List<string> Prefixes()
    {
      return this.m_prefixes;
    }

    public ArchiveParams Prefixes(List<string> prefixes)
    {
      this.m_prefixes = prefixes;
      return this;
    }

    public override void Check()
    {
      if ((this.m_publicIds == null || this.m_publicIds.Count == 0) && (this.m_prefixes == null || this.m_prefixes.Count == 0) && (this.m_tags == null || this.m_tags.Count == 0))
        throw new ArgumentException("At least one of the following \"filtering\" parameters needs to be specified: PublicIds, Tags or Prefixes.");
    }

    public virtual ArchiveCallMode Mode()
    {
      return this.m_mode;
    }

    public ArchiveParams Mode(ArchiveCallMode mode)
    {
      this.m_mode = mode;
      return this;
    }

    public string ResourceType()
    {
      return this.m_resourceType;
    }

    public ArchiveParams ResourceType(string resourceType)
    {
      this.m_resourceType = resourceType;
      return this;
    }

    public string Type()
    {
      return this.m_type;
    }

    public ArchiveParams Type(string type)
    {
      this.m_type = type;
      return this;
    }

    public List<Transformation> Transformations()
    {
      return this.m_transformations;
    }

    public ArchiveParams Transformations(List<Transformation> transformations)
    {
      this.m_transformations = transformations;
      return this;
    }

    public ArchiveFormat TargetFormat()
    {
      return this.m_targetFormat;
    }

    public ArchiveParams TargetFormat(ArchiveFormat targetFormat)
    {
      this.m_targetFormat = targetFormat;
      return this;
    }

    public string TargetPublicId()
    {
      return this.m_targetPublicId;
    }

    public ArchiveParams TargetPublicId(string targetPublicId)
    {
      this.m_targetPublicId = targetPublicId;
      return this;
    }

    public bool IsFlattenFolders()
    {
      return this.m_flattenFolders;
    }

    public ArchiveParams FlattenFolders(bool flattenFolders)
    {
      this.m_flattenFolders = flattenFolders;
      return this;
    }

    public bool IsFlattenTransformations()
    {
      return this.m_flattenTransformations;
    }

    public ArchiveParams FlattenTransformations(bool flattenTransformations)
    {
      this.m_flattenTransformations = flattenTransformations;
      return this;
    }

    public int ExpiresAt()
    {
      return this.m_expiresAt;
    }

    public ArchiveParams ExpiresAt(int expiresAt)
    {
      this.m_expiresAt = expiresAt;
      return this;
    }

    public bool IsUseOriginalFilename()
    {
      return this.m_useOriginalFilename;
    }

    public ArchiveParams UseOriginalFilename(bool useOriginalFilename)
    {
      this.m_useOriginalFilename = useOriginalFilename;
      return this;
    }

    public bool IsAsync()
    {
      return this.m_async;
    }

    public ArchiveParams Async(bool async)
    {
      this.m_async = async;
      return this;
    }

    public string NotificationUrl()
    {
      return this.m_notificationUrl;
    }

    public ArchiveParams NotificationUrl(string notificationUrl)
    {
      this.m_notificationUrl = notificationUrl;
      return this;
    }

    public List<string> TargetTags()
    {
      return this.m_targetTags;
    }

    public ArchiveParams TargetTags(List<string> targetTags)
    {
      this.m_targetTags = targetTags;
      return this;
    }

    public bool IsKeepDerived()
    {
      return this.m_keepDerived;
    }

    public ArchiveParams KeepDerived(bool keepDerived)
    {
      this.m_keepDerived = keepDerived;
      return this;
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      this.Check();
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "mode", Api.GetCloudinaryParam<ArchiveCallMode>(this.Mode()));
      if (this.m_tags != null && this.m_tags.Count > 0)
        this.AddParam(paramsDictionary, "tags", (IEnumerable<string>) this.m_tags);
      if (this.m_publicIds != null && this.m_publicIds.Count > 0)
        this.AddParam(paramsDictionary, "public_ids", (IEnumerable<string>) this.m_publicIds);
      if (this.m_prefixes != null && this.m_prefixes.Count > 0)
        this.AddParam(paramsDictionary, "prefixes", (IEnumerable<string>) this.m_prefixes);
      if (!string.IsNullOrEmpty(this.m_type))
        this.AddParam(paramsDictionary, "type", this.m_type);
      if (this.m_transformations != null && this.m_transformations.Count > 0)
        this.AddParam(paramsDictionary, "transformations", string.Join("/", this.m_transformations.Select(t => t.ToString()).ToArray()));
      if (this.m_targetFormat != ArchiveFormat.Zip)
        this.AddParam(paramsDictionary, "target_format", Api.GetCloudinaryParam<ArchiveFormat>(this.m_targetFormat));
      if (this.m_flattenFolders)
        this.AddParam(paramsDictionary, "flatten_folders", this.m_flattenFolders);
      if (this.m_flattenTransformations)
        this.AddParam(paramsDictionary, "flatten_transformations", this.m_flattenTransformations);
      if (this.m_useOriginalFilename)
        this.AddParam(paramsDictionary, "use_original_filename", this.m_useOriginalFilename);
      if (!string.IsNullOrEmpty(this.m_notificationUrl))
        this.AddParam(paramsDictionary, "notification_url", this.m_notificationUrl);
      if (this.m_keepDerived)
        this.AddParam(paramsDictionary, "keep_derived", this.m_keepDerived);
      if (this.m_mode == ArchiveCallMode.Create)
      {
        if (this.m_async)
          this.AddParam(paramsDictionary, "async", this.m_async);
        if (!string.IsNullOrEmpty(this.m_targetPublicId))
          this.AddParam(paramsDictionary, "target_public_id", this.m_targetPublicId);
        if (this.m_targetTags != null && this.m_targetTags.Count > 0)
          this.AddParam(paramsDictionary, "target_tags", (IEnumerable<string>) this.m_targetTags);
      }
      if (this.m_expiresAt > 0 && this.m_mode == ArchiveCallMode.Download)
        this.AddParam(paramsDictionary, "expires_at", (float) this.m_expiresAt);
      return paramsDictionary;
    }
  }
}
