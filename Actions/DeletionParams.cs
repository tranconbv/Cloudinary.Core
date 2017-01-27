// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DeletionParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class DeletionParams : BaseParams
  {
    public string PublicId { get; set; }

    public string Type { get; set; }

    public bool Invalidate { get; set; }

    public ResourceType ResourceType { get; set; }

    public DeletionParams(string publicId)
    {
      this.Type = "upload";
      this.ResourceType = ResourceType.Image;
      this.PublicId = publicId;
    }

    public override void Check()
    {
      if (string.IsNullOrEmpty(this.PublicId))
        throw new ArgumentException("PublicId must be specified in UploadParams!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "public_id", this.PublicId);
      this.AddParam(paramsDictionary, "type", this.Type);
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      return paramsDictionary;
    }
  }
}
