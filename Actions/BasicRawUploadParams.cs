// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.BasicRawUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class BasicRawUploadParams : BaseParams
  {
    public FileDescription File { get; set; }

    public string PublicId { get; set; }

    public bool? Backup { get; set; }

    public string Type { get; set; }

    public virtual ResourceType ResourceType
    {
      get
      {
        return ResourceType.Raw;
      }
    }

    public override void Check()
    {
      if (this.File == null)
        throw new ArgumentException("File must be specified in UploadParams!");
      if (!this.File.IsRemote && this.File.Stream == null && string.IsNullOrEmpty(this.File.FilePath))
        throw new ArgumentException("File is not ready!");
      if (string.IsNullOrEmpty(this.File.FileName))
        throw new ArgumentException("File name must be specified in UploadParams!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "public_id", this.PublicId);
      this.AddParam(paramsDictionary, "type", this.Type);
      if (this.Backup.HasValue)
        this.AddParam(paramsDictionary, "backup", this.Backup.Value);
      return paramsDictionary;
    }
  }
}
