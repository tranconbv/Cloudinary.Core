// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RenameParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class RenameParams : BaseParams
  {
    public string FromPublicId { get; set; }

    public string ToPublicId { get; set; }

    public string Type { get; set; }

    public bool Overwrite { get; set; }

    public bool Invalidate { get; set; }

    public RenameParams(string fromPublicId, string toPublicId)
    {
      this.FromPublicId = fromPublicId;
      this.ToPublicId = toPublicId;
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "from_public_id", this.FromPublicId);
      this.AddParam(paramsDictionary, "to_public_id", this.ToPublicId);
      this.AddParam(paramsDictionary, "overwrite", this.Overwrite);
      this.AddParam(paramsDictionary, "type", this.Type);
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      return paramsDictionary;
    }

    public override void Check()
    {
      if (string.IsNullOrEmpty(this.FromPublicId))
        throw new ArgumentException("FromPublicId can't be null!");
      if (string.IsNullOrEmpty(this.ToPublicId))
        throw new ArgumentException("ToPublicId can't be null!");
    }
  }
}
