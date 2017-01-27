// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ExplicitParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudinaryDotNet.Actions
{
  public class ExplicitParams : BaseParams
  {
    public List<Transformation> EagerTransforms { get; set; }

    public bool? EagerAsync { get; set; }

    public string EagerNotificationUrl { get; set; }

    public string Type { get; set; }

    public string PublicId { get; set; }

    public Dictionary<string, string> Headers { get; set; }

    public string Tags { get; set; }

    public object FaceCoordinates { get; set; }

    public object CustomCoordinates { get; set; }

    public StringDictionary Context { get; set; }

    public List<ResponsiveBreakpoint> ResponsiveBreakpoints { get; set; }

    public bool Invalidate { get; set; }

    public ExplicitParams(string publicId)
    {
      this.PublicId = publicId;
      this.Type = string.Empty;
      this.Tags = string.Empty;
    }

    public override void Check()
    {
      if (string.IsNullOrEmpty(this.PublicId))
        throw new ArgumentException("PublicId must be set!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "public_id", this.PublicId);
      this.AddParam(paramsDictionary, "tags", this.Tags);
      this.AddParam(paramsDictionary, "type", this.Type);
      this.AddParam(paramsDictionary, "eager_async", this.EagerAsync);
      this.AddParam(paramsDictionary, "eager_notification_url", this.EagerNotificationUrl);
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      this.AddCoordinates(paramsDictionary, "face_coordinates", this.FaceCoordinates);
      this.AddCoordinates(paramsDictionary, "custom_coordinates", this.CustomCoordinates);
      if (this.EagerTransforms != null)
        this.AddParam(paramsDictionary, "eager", string.Join("|", this.EagerTransforms.Select<Transformation, string>((Func<Transformation, string>) (t => t.Generate())).ToArray<string>()));
      if (this.Context != null && this.Context.Count > 0)
        this.AddParam(paramsDictionary, "context", string.Join("|", this.Context.Pairs));
      if (this.ResponsiveBreakpoints != null && this.ResponsiveBreakpoints.Count > 0)
        this.AddParam(paramsDictionary, "responsive_breakpoints", JsonConvert.SerializeObject((object) this.ResponsiveBreakpoints));
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
