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
        private bool m_async;
        private int m_expiresAt;
        private bool m_flattenFolders;
        private bool m_flattenTransformations;
        private bool m_keepDerived;
        private ArchiveCallMode m_mode = ArchiveCallMode.Create;
        private string m_notificationUrl;
        private List<string> m_prefixes;
        private List<string> m_publicIds;
        private string m_resourceType;
        private List<string> m_tags;
        private ArchiveFormat m_targetFormat;
        private string m_targetPublicId;
        private List<string> m_targetTags;
        private List<Transformation> m_transformations;
        private string m_type;
        private bool m_useOriginalFilename;

        public List<string> PublicIds()
        {
            return m_publicIds;
        }

        public ArchiveParams PublicIds(List<string> publicIds)
        {
            m_publicIds = publicIds;
            return this;
        }

        public List<string> Tags()
        {
            return m_tags;
        }

        public ArchiveParams Tags(List<string> tags)
        {
            m_tags = tags;
            return this;
        }

        public List<string> Prefixes()
        {
            return m_prefixes;
        }

        public ArchiveParams Prefixes(List<string> prefixes)
        {
            m_prefixes = prefixes;
            return this;
        }

        public override void Check()
        {
            if ((m_publicIds == null || m_publicIds.Count == 0) && (m_prefixes == null || m_prefixes.Count == 0) && (m_tags == null || m_tags.Count == 0))
                throw new ArgumentException("At least one of the following \"filtering\" parameters needs to be specified: PublicIds, Tags or Prefixes.");
        }

        public virtual ArchiveCallMode Mode()
        {
            return m_mode;
        }

        public ArchiveParams Mode(ArchiveCallMode mode)
        {
            m_mode = mode;
            return this;
        }

        public string ResourceType()
        {
            return m_resourceType;
        }

        public ArchiveParams ResourceType(string resourceType)
        {
            m_resourceType = resourceType;
            return this;
        }

        public string Type()
        {
            return m_type;
        }

        public ArchiveParams Type(string type)
        {
            m_type = type;
            return this;
        }

        public List<Transformation> Transformations()
        {
            return m_transformations;
        }

        public ArchiveParams Transformations(List<Transformation> transformations)
        {
            m_transformations = transformations;
            return this;
        }

        public ArchiveFormat TargetFormat()
        {
            return m_targetFormat;
        }

        public ArchiveParams TargetFormat(ArchiveFormat targetFormat)
        {
            m_targetFormat = targetFormat;
            return this;
        }

        public string TargetPublicId()
        {
            return m_targetPublicId;
        }

        public ArchiveParams TargetPublicId(string targetPublicId)
        {
            m_targetPublicId = targetPublicId;
            return this;
        }

        public bool IsFlattenFolders()
        {
            return m_flattenFolders;
        }

        public ArchiveParams FlattenFolders(bool flattenFolders)
        {
            m_flattenFolders = flattenFolders;
            return this;
        }

        public bool IsFlattenTransformations()
        {
            return m_flattenTransformations;
        }

        public ArchiveParams FlattenTransformations(bool flattenTransformations)
        {
            m_flattenTransformations = flattenTransformations;
            return this;
        }

        public int ExpiresAt()
        {
            return m_expiresAt;
        }

        public ArchiveParams ExpiresAt(int expiresAt)
        {
            m_expiresAt = expiresAt;
            return this;
        }

        public bool IsUseOriginalFilename()
        {
            return m_useOriginalFilename;
        }

        public ArchiveParams UseOriginalFilename(bool useOriginalFilename)
        {
            m_useOriginalFilename = useOriginalFilename;
            return this;
        }

        public bool IsAsync()
        {
            return m_async;
        }

        public ArchiveParams Async(bool async)
        {
            m_async = async;
            return this;
        }

        public string NotificationUrl()
        {
            return m_notificationUrl;
        }

        public ArchiveParams NotificationUrl(string notificationUrl)
        {
            m_notificationUrl = notificationUrl;
            return this;
        }

        public List<string> TargetTags()
        {
            return m_targetTags;
        }

        public ArchiveParams TargetTags(List<string> targetTags)
        {
            m_targetTags = targetTags;
            return this;
        }

        public bool IsKeepDerived()
        {
            return m_keepDerived;
        }

        public ArchiveParams KeepDerived(bool keepDerived)
        {
            m_keepDerived = keepDerived;
            return this;
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            Check();
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "mode", Api.GetCloudinaryParam(Mode()));
            if (m_tags != null && m_tags.Count > 0)
                AddParam(paramsDictionary, "tags", m_tags);
            if (m_publicIds != null && m_publicIds.Count > 0)
                AddParam(paramsDictionary, "public_ids", m_publicIds);
            if (m_prefixes != null && m_prefixes.Count > 0)
                AddParam(paramsDictionary, "prefixes", m_prefixes);
            if (!string.IsNullOrEmpty(m_type))
                AddParam(paramsDictionary, "type", m_type);
            if (m_transformations != null && m_transformations.Count > 0)
                AddParam(paramsDictionary, "transformations", string.Join("/", m_transformations.Select(t => t.ToString()).ToArray()));
            if (m_targetFormat != ArchiveFormat.Zip)
                AddParam(paramsDictionary, "target_format", Api.GetCloudinaryParam(m_targetFormat));
            if (m_flattenFolders)
                AddParam(paramsDictionary, "flatten_folders", m_flattenFolders);
            if (m_flattenTransformations)
                AddParam(paramsDictionary, "flatten_transformations", m_flattenTransformations);
            if (m_useOriginalFilename)
                AddParam(paramsDictionary, "use_original_filename", m_useOriginalFilename);
            if (!string.IsNullOrEmpty(m_notificationUrl))
                AddParam(paramsDictionary, "notification_url", m_notificationUrl);
            if (m_keepDerived)
                AddParam(paramsDictionary, "keep_derived", m_keepDerived);
            if (m_mode == ArchiveCallMode.Create)
            {
                if (m_async)
                    AddParam(paramsDictionary, "async", m_async);
                if (!string.IsNullOrEmpty(m_targetPublicId))
                    AddParam(paramsDictionary, "target_public_id", m_targetPublicId);
                if (m_targetTags != null && m_targetTags.Count > 0)
                    AddParam(paramsDictionary, "target_tags", m_targetTags);
            }
            if (m_expiresAt > 0 && m_mode == ArchiveCallMode.Download)
                AddParam(paramsDictionary, "expires_at", m_expiresAt);
            return paramsDictionary;
        }
    }
}