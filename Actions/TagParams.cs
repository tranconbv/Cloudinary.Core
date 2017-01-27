// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.TagParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class TagParams : BaseParams
  {
    private List<string> m_publicIds = new List<string>();

    public List<string> PublicIds
    {
      get
      {
        return this.m_publicIds;
      }
      set
      {
        this.m_publicIds = value;
      }
    }

    public string Tag { get; set; }

    public string Type { get; set; }

    public TagCommand Command { get; set; }

    public override void Check()
    {
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "tag", this.Tag);
      this.AddParam(paramsDictionary, "public_ids", (IEnumerable<string>) this.PublicIds);
      this.AddParam(paramsDictionary, "command", Api.GetCloudinaryParam<TagCommand>(this.Command));
      return paramsDictionary;
    }
  }
}
