// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ImageUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet.Actions
{
  public class ImageUploadParams : RawUploadParams
  {
    public string Format { get; set; }

    public Transformation Transformation { get; set; }

    public List<Transformation> EagerTransforms { get; set; }

    public new string Type
    {
      get
      {
        return base.Type;
      }
      set
      {
        base.Type = value;
      }
    }

    public override ResourceType ResourceType
    {
      get
      {
        return ResourceType.Image;
      }
    }

    public bool? Exif { get; set; }

    public bool? Colors { get; set; }

    public bool? Faces { get; set; }

    public object FaceCoordinates { get; set; }

    public object CustomCoordinates { get; set; }

    public bool? Metadata { get; set; }

    public bool? EagerAsync { get; set; }

    public string EagerNotificationUrl { get; set; }

    public string Categorization { get; set; }

    public string BackgroundRemoval { get; set; }

    public float? AutoTagging { get; set; }

    public string Detection { get; set; }

    public string SimilaritySearch { get; set; }

    public string Ocr { get; set; }

    public bool? ReturnDeleteToken { get; set; }

    public string UploadPreset { get; set; }

    public bool? Unsigned { get; set; }

    public bool? Phash { get; set; }

    public List<ResponsiveBreakpoint> ResponsiveBreakpoints { get; set; }

    public ImageUploadParams()
    {
      this.Overwrite = new bool?();
      this.UniqueFilename = new bool?();
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "format", this.Format);
      this.AddParam(paramsDictionary, "exif", this.Exif);
      this.AddParam(paramsDictionary, "faces", this.Faces);
      this.AddParam(paramsDictionary, "colors", this.Colors);
      this.AddParam(paramsDictionary, "image_metadata", this.Metadata);
      this.AddParam(paramsDictionary, "eager_async", this.EagerAsync);
      this.AddParam(paramsDictionary, "eager_notification_url", this.EagerNotificationUrl);
      this.AddParam(paramsDictionary, "categorization", this.Categorization);
      this.AddParam(paramsDictionary, "detection", this.Detection);
      this.AddParam(paramsDictionary, "ocr", this.Ocr);
      this.AddParam(paramsDictionary, "similarity_search", this.SimilaritySearch);
      this.AddParam(paramsDictionary, "upload_preset", this.UploadPreset);
      this.AddParam(paramsDictionary, "unsigned", this.Unsigned);
      this.AddParam(paramsDictionary, "phash", this.Phash);
      this.AddParam(paramsDictionary, "background_removal", this.BackgroundRemoval);
      this.AddParam(paramsDictionary, "return_delete_token", this.ReturnDeleteToken);
      if (this.AutoTagging.HasValue)
        this.AddParam(paramsDictionary, "auto_tagging", this.AutoTagging.Value);
      this.AddCoordinates(paramsDictionary, "face_coordinates", this.FaceCoordinates);
      this.AddCoordinates(paramsDictionary, "custom_coordinates", this.CustomCoordinates);
      if (this.Transformation != null)
        this.AddParam(paramsDictionary, "transformation", this.Transformation.Generate());
      if (this.EagerTransforms != null && this.EagerTransforms.Count > 0)
        this.AddParam(paramsDictionary, "eager", string.Join("|", this.EagerTransforms.Select<Transformation, string>((Func<Transformation, string>) (t => t.Generate())).ToArray<string>()));
      if (this.ResponsiveBreakpoints != null && this.ResponsiveBreakpoints.Count > 0)
        this.AddParam(paramsDictionary, "responsive_breakpoints", JsonConvert.SerializeObject((object) this.ResponsiveBreakpoints));
      return paramsDictionary;
    }
  }
}
