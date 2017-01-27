// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.GetResourceParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class GetResourceParams : BaseParams
  {
    public string PublicId { get; set; }

    public ResourceType ResourceType { get; set; }

    public string Type { get; set; }

    public bool Exif { get; set; }

    public bool Colors { get; set; }

    public bool Faces { get; set; }

    public bool Metadata { get; set; }

    public bool Coordinates { get; set; }

    public int MaxResults { get; set; }

    public bool Phash { get; set; }

    public GetResourceParams(string publicId)
    {
      this.PublicId = publicId;
      this.Type = "upload";
      this.Exif = false;
      this.Colors = false;
      this.Faces = false;
    }

    public override void Check()
    {
      if (string.IsNullOrEmpty(this.PublicId))
        throw new ArgumentException("PublicId must be set!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.MaxResults > 0)
        this.AddParam(paramsDictionary, "max_results", this.MaxResults.ToString());
      this.AddParam(paramsDictionary, "exif", this.Exif);
      this.AddParam(paramsDictionary, "colors", this.Colors);
      this.AddParam(paramsDictionary, "faces", this.Faces);
      this.AddParam(paramsDictionary, "image_metadata", this.Metadata);
      this.AddParam(paramsDictionary, "phash", this.Phash);
      this.AddParam(paramsDictionary, "coordinates", this.Coordinates);
      return paramsDictionary;
    }
  }
}
