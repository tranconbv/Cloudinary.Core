// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.BaseLayer`1
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet
{
    public abstract class BaseLayer<T> : BaseLayer where T : BaseLayer<T>
    {
        protected string m_format;
        protected string m_publicId;
        protected string m_resourceType;
        protected string m_type;

        public T ResourceType(string resourceType)
        {
            m_resourceType = resourceType;
            return (T) this;
        }

        public T Type(string type)
        {
            m_type = type;
            return (T) this;
        }

        public T PublicId(string publicId)
        {
            m_publicId = publicId.Replace('/', ':');
            return (T) this;
        }

        public T Format(string format)
        {
            m_format = format;
            return (T) this;
        }

        public virtual string AdditionalParams()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var stringList = new List<string>();
            if (!string.IsNullOrEmpty(m_resourceType) && !m_resourceType.Equals("image"))
                stringList.Add(m_resourceType);
            if (!string.IsNullOrEmpty(m_type) && !m_type.Equals("upload"))
                stringList.Add(m_type);
            var str = AdditionalParams();
            if (!string.IsNullOrEmpty(str))
                stringList.Add(str);
            if (!string.IsNullOrEmpty(m_publicId))
                stringList.Add(FormattedPublicId());
            return string.Join(":", stringList.ToArray());
        }

        private string FormattedPublicId()
        {
            var str = m_publicId;
            if (!string.IsNullOrEmpty(m_format))
                str = string.Format("{0}.{1}", str, m_format);
            return str;
        }
    }
}