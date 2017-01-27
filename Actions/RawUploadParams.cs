// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RawUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Text;

namespace CloudinaryDotNet.Actions
{
  public class RawUploadParams : BasicRawUploadParams
  {
    public string Tags { get; set; }

    public bool? Invalidate { get; set; }

    public Dictionary<string, string> Headers { get; set; }

    public bool? UseFilename { get; set; }

    public bool? UniqueFilename { get; set; }

    public bool? DiscardOriginalFilename { get; set; }

    public string NotificationUrl { get; set; }

    public string Proxy { get; set; }

    public string Folder { get; set; }

    public bool? Overwrite { get; set; }

    public string RawConvert { get; set; }

    public StringDictionary Context { get; set; }

    public string[] AllowedFormats { get; set; }

    public string Moderation { get; set; }

    public RawUploadParams()
    {
      this.Overwrite = new bool?(true);
      this.UniqueFilename = new bool?(true);
      this.Context = new StringDictionary();
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "tags", this.Tags);
      this.AddParam(paramsDictionary, "use_filename", this.UseFilename);
      this.AddParam(paramsDictionary, "moderation", this.Moderation);
      if (this.UseFilename.HasValue && this.UseFilename.Value)
        this.AddParam(paramsDictionary, "unique_filename", this.UniqueFilename);
      if (this.AllowedFormats != null)
        this.AddParam(paramsDictionary, "allowed_formats", string.Join(",", this.AllowedFormats));
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      this.AddParam(paramsDictionary, "discard_original_filename", this.DiscardOriginalFilename);
      this.AddParam(paramsDictionary, "notification_url", this.NotificationUrl);
      this.AddParam(paramsDictionary, "proxy", this.Proxy);
      this.AddParam(paramsDictionary, "folder", this.Folder);
      this.AddParam(paramsDictionary, "raw_convert", this.RawConvert);
      this.AddParam(paramsDictionary, "overwrite", this.Overwrite);
      if (this.Context != null && this.Context.Count > 0)
        this.AddParam(paramsDictionary, "context", string.Join("|", this.Context.Pairs));
      if (this.Headers != null && this.Headers.Count > 0)
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (KeyValuePair<string, string> header in this.Headers)
          stringBuilder.AppendFormat("{0}: {1}\n", (object) header.Key, (object) header.Value);
        paramsDictionary.Add("headers", (object) stringBuilder.ToString());
      }
      return paramsDictionary;
    }
  }
}
