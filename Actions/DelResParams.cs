// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DelResParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class DelResParams : BaseParams
    {
        private bool m_all;
        private string m_prefix;
        private List<string> m_publicIds = new List<string>();
        private string m_tag;

        public DelResParams()
        {
            Type = "upload";
        }

        public ResourceType ResourceType { get; set; }

        public string Type { get; set; }

        public bool KeepOriginal { get; set; }

        public bool Invalidate { get; set; }

        public string NextCursor { get; set; }

        public List<string> PublicIds
        {
            get { return m_publicIds; }
            set
            {
                m_publicIds = value;
                m_prefix = string.Empty;
                m_tag = string.Empty;
                m_all = false;
            }
        }

        public string Prefix
        {
            get { return m_prefix; }
            set
            {
                m_publicIds = null;
                m_tag = string.Empty;
                m_prefix = value;
                m_all = false;
            }
        }

        public string Tag
        {
            get { return m_tag; }
            set
            {
                m_publicIds = null;
                m_prefix = string.Empty;
                m_tag = value;
                m_all = false;
            }
        }

        public bool All
        {
            get { return m_all; }
            set
            {
                m_publicIds = null;
                m_prefix = string.Empty;
                m_tag = string.Empty;
                m_all = true;
            }
        }

        public override void Check()
        {
            if ((PublicIds == null || PublicIds.Count == 0) && string.IsNullOrEmpty(Prefix) && string.IsNullOrEmpty(Tag) && !All)
                throw new ArgumentException("Either PublicIds or Prefix or Tag must be specified!");
            if (!string.IsNullOrEmpty(Tag) && !string.IsNullOrEmpty(Type))
                throw new ArgumentException("Type of resource cannot specified when tag is given!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "keep_original", KeepOriginal);
            AddParam(paramsDictionary, "invalidate", Invalidate);
            AddParam(paramsDictionary, "next_cursor", NextCursor);
            if (!string.IsNullOrEmpty(Tag))
                return paramsDictionary;
            if (!string.IsNullOrEmpty(Prefix))
                paramsDictionary.Add("prefix", Prefix);
            else if (PublicIds != null && PublicIds.Count > 0)
                paramsDictionary.Add("public_ids", PublicIds);
            if (m_all)
                AddParam(paramsDictionary, "all", true);
            return paramsDictionary;
        }
    }
}