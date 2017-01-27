// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListTagsParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class ListTagsParams : BaseParams
  {
    public ResourceType ResourceType { get; set; }

    public string Prefix { get; set; }

    public int MaxResults { get; set; }

    public string NextCursor { get; set; }

    public ListTagsParams()
    {
      this.NextCursor = string.Empty;
      this.Prefix = string.Empty;
    }

    public override void Check()
    {
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.MaxResults > 0)
        this.AddParam(paramsDictionary, "max_results", this.MaxResults.ToString());
      this.AddParam(paramsDictionary, "next_cursor", this.NextCursor);
      this.AddParam(paramsDictionary, "prefix", this.Prefix);
      return paramsDictionary;
    }
  }
}
