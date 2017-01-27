// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListUploadPresetsParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class ListUploadPresetsParams : BaseParams
  {
    public int MaxResults { get; set; }

    public string NextCursor { get; set; }

    public override void Check()
    {
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.MaxResults > 0)
        this.AddParam(paramsDictionary, "max_results", this.MaxResults.ToString());
      this.AddParam(paramsDictionary, "next_cursor", this.NextCursor);
      return paramsDictionary;
    }
  }
}
