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
    protected string m_resourceType;
    protected string m_type;
    protected string m_publicId;
    protected string m_format;

    public T ResourceType(string resourceType)
    {
      this.m_resourceType = resourceType;
      return (T) this;
    }

    public T Type(string type)
    {
      this.m_type = type;
      return (T) this;
    }

    public T PublicId(string publicId)
    {
      this.m_publicId = publicId.Replace('/', ':');
      return (T) this;
    }

    public T Format(string format)
    {
      this.m_format = format;
      return (T) this;
    }

    public virtual string AdditionalParams()
    {
      return string.Empty;
    }

    public override string ToString()
    {
      List<string> stringList = new List<string>();
      if (!string.IsNullOrEmpty(this.m_resourceType) && !this.m_resourceType.Equals("image"))
        stringList.Add(this.m_resourceType);
      if (!string.IsNullOrEmpty(this.m_type) && !this.m_type.Equals("upload"))
        stringList.Add(this.m_type);
      string str = this.AdditionalParams();
      if (!string.IsNullOrEmpty(str))
        stringList.Add(str);
      if (!string.IsNullOrEmpty(this.m_publicId))
        stringList.Add(this.FormattedPublicId());
      return string.Join(":", stringList.ToArray());
    }

    private string FormattedPublicId()
    {
      string str = this.m_publicId;
      if (!string.IsNullOrEmpty(this.m_format))
        str = string.Format("{0}.{1}", (object) str, (object) this.m_format);
      return str;
    }
  }
}
