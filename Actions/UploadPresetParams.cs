// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadPresetParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet.Actions
{
  public class UploadPresetParams : BaseParams
  {
    public string Name { get; set; }

    public bool Unsigned { get; set; }

    public bool DisallowPublicId { get; set; }

    public bool? Backup { get; set; }

    public string Type { get; set; }

    public string Tags { get; set; }

    public bool Invalidate { get; set; }

    public bool UseFilename { get; set; }

    public bool? UniqueFilename { get; set; }

    public bool DiscardOriginalFilename { get; set; }

    public string NotificationUrl { get; set; }

    public string Proxy { get; set; }

    public string Folder { get; set; }

    public bool? Overwrite { get; set; }

    public string RawConvert { get; set; }

    public StringDictionary Context { get; set; }

    public string[] AllowedFormats { get; set; }

    public string Moderation { get; set; }

    public string Format { get; set; }

    public object Transformation { get; set; }

    public ICollection<object> EagerTransforms { get; set; }

    public bool Exif { get; set; }

    public bool Colors { get; set; }

    public bool Faces { get; set; }

    public object FaceCoordinates { get; set; }

    public bool Metadata { get; set; }

    public bool EagerAsync { get; set; }

    public string EagerNotificationUrl { get; set; }

    public string Categorization { get; set; }

    public float? AutoTagging { get; set; }

    public string Detection { get; set; }

    public string SimilaritySearch { get; set; }

    public string Ocr { get; set; }

    public UploadPresetParams()
    {
    }

    public UploadPresetParams(GetUploadPresetResult preset)
    {
      this.Name = preset.Name;
      this.Unsigned = preset.Unsigned;
      if (preset.Settings == null)
        return;
      this.DisallowPublicId = preset.Settings.DisallowPublicId;
      this.Backup = preset.Settings.Backup;
      this.Type = preset.Settings.Type;
      if (preset.Settings.Tags != null)
      {
        if (preset.Settings.Tags.Type == JTokenType.String)
          this.Tags = preset.Settings.Tags.ToString();
        else if (preset.Settings.Tags.Type == JTokenType.Array)
          this.Tags = string.Join(",", preset.Settings.Tags.Values<string>().ToArray<string>());
      }
      this.Invalidate = preset.Settings.Invalidate;
      this.UseFilename = preset.Settings.UseFilename;
      this.UniqueFilename = preset.Settings.UniqueFilename;
      this.DiscardOriginalFilename = preset.Settings.DiscardOriginalFilename;
      this.NotificationUrl = preset.Settings.NotificationUrl;
      this.Proxy = preset.Settings.Proxy;
      this.Folder = preset.Settings.Folder;
      this.Overwrite = preset.Settings.Overwrite;
      this.RawConvert = preset.Settings.RawConvert;
      if (preset.Settings.Context != null)
      {
        this.Context = new StringDictionary();
        foreach (JProperty jproperty in (IEnumerable<JToken>) preset.Settings.Context)
          this.Context.Add(jproperty.Name, jproperty.Value.ToString());
      }
      if (preset.Settings.AllowedFormats != null)
      {
        if (preset.Settings.AllowedFormats.Type == JTokenType.String)
          this.AllowedFormats = preset.Settings.AllowedFormats.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        else if (preset.Settings.AllowedFormats.Type == JTokenType.Array)
          this.AllowedFormats = preset.Settings.AllowedFormats.Select<JToken, string>((Func<JToken, string>) (t => t.ToString())).ToArray<string>();
      }
      this.Moderation = preset.Settings.Moderation;
      this.Format = preset.Settings.Format;
      if (preset.Settings.Transformation != null)
      {
        if (preset.Settings.Transformation.Type == JTokenType.String)
          this.Transformation = (object) preset.Settings.Transformation.ToString();
        else if (preset.Settings.Transformation.Type == JTokenType.Array)
        {
          Dictionary<string, object> transformParams = new Dictionary<string, object>();
          foreach (JObject jobject in (IEnumerable<JToken>) preset.Settings.Transformation)
          {
            foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
              transformParams.Add(keyValuePair.Key, (object) keyValuePair.Value.ToString());
          }
          this.Transformation = (object) new CloudinaryDotNet.Transformation(transformParams);
        }
      }
      if (preset.Settings.EagerTransforms != null)
      {
        this.EagerTransforms = (ICollection<object>) new List<object>();
        foreach (JToken eagerTransform in (IEnumerable<JToken>) preset.Settings.EagerTransforms)
        {
          if (eagerTransform.Type == JTokenType.String)
            this.EagerTransforms.Add((object) eagerTransform.ToString());
          else if (eagerTransform.Type == JTokenType.Array)
          {
            Dictionary<string, object> transformParams = new Dictionary<string, object>();
            foreach (JObject jobject in (IEnumerable<JToken>) eagerTransform)
            {
              foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
                transformParams.Add(keyValuePair.Key, (object) keyValuePair.Value.ToString());
            }
            this.EagerTransforms.Add((object) new CloudinaryDotNet.Transformation(transformParams));
          }
        }
      }
      this.Exif = preset.Settings.Exif;
      this.Colors = preset.Settings.Colors;
      this.Faces = preset.Settings.Faces;
      if (preset.Settings.FaceCoordinates != null)
      {
        if (preset.Settings.FaceCoordinates.Type == JTokenType.String)
          this.FaceCoordinates = (object) preset.Settings.FaceCoordinates.ToString();
        else if (preset.Settings.FaceCoordinates.Type == JTokenType.Array)
        {
          List<Rectangle> rectangleList = new List<Rectangle>();
          foreach (JToken faceCoordinate in (IEnumerable<JToken>) preset.Settings.FaceCoordinates)
            rectangleList.Add(new Rectangle(faceCoordinate[(object) 0].Value<int>(), faceCoordinate[(object) 1].Value<int>(), faceCoordinate[(object) 2].Value<int>(), faceCoordinate[(object) 3].Value<int>()));
        }
      }
      this.Metadata = preset.Settings.Metadata;
      this.EagerAsync = preset.Settings.EagerAsync;
      this.EagerNotificationUrl = preset.Settings.EagerNotificationUrl;
      this.Categorization = preset.Settings.Categorization;
      this.AutoTagging = preset.Settings.AutoTagging;
      this.Detection = preset.Settings.Detection;
      this.SimilaritySearch = preset.Settings.SimilaritySearch;
      this.Ocr = preset.Settings.Ocr;
    }

    public override void Check()
    {
      if (this.Overwrite.HasValue && (this.Overwrite.Value && this.Unsigned))
        throw new ArgumentException("Don't set both Overwrite and Unsigned to true!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "name", this.Name);
      this.AddParam(paramsDictionary, "unsigned", this.Unsigned);
      this.AddParam(paramsDictionary, "disallow_public_id", this.DisallowPublicId);
      this.AddParam(paramsDictionary, "type", this.Type);
      this.AddParam(paramsDictionary, "tags", this.Tags);
      this.AddParam(paramsDictionary, "use_filename", this.UseFilename);
      this.AddParam(paramsDictionary, "moderation", this.Moderation);
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
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      this.AddParam(paramsDictionary, "discard_original_filename", this.DiscardOriginalFilename);
      this.AddParam(paramsDictionary, "notification_url", this.NotificationUrl);
      this.AddParam(paramsDictionary, "proxy", this.Proxy);
      this.AddParam(paramsDictionary, "folder", this.Folder);
      this.AddParam(paramsDictionary, "raw_convert", this.RawConvert);
      this.AddParam(paramsDictionary, "backup", this.Backup);
      this.AddParam(paramsDictionary, "overwrite", this.Overwrite);
      this.AddParam(paramsDictionary, "unique_filename", this.UniqueFilename);
      this.AddParam(paramsDictionary, "transformation", this.GetTransformation(this.Transformation));
      if (this.AutoTagging.HasValue)
        this.AddParam(paramsDictionary, "auto_tagging", this.AutoTagging.Value);
      if (this.FaceCoordinates != null)
        this.AddParam(paramsDictionary, "face_coordinates", this.FaceCoordinates.ToString());
      if (this.EagerTransforms != null && this.EagerTransforms.Count > 0)
        this.AddParam(paramsDictionary, "eager", string.Join("|", this.EagerTransforms.Select<object, string>(new Func<object, string>(this.GetTransformation)).ToArray<string>()));
      if (this.AllowedFormats != null)
        this.AddParam(paramsDictionary, "allowed_formats", string.Join(",", this.AllowedFormats));
      if (this.Context != null && this.Context.Count > 0)
        this.AddParam(paramsDictionary, "context", string.Join("|", this.Context.Pairs));
      return paramsDictionary;
    }

    private string GetTransformation(object o)
    {
      if (o == null)
        return (string) null;
      if (o is string)
        return (string) o;
      if (o is CloudinaryDotNet.Transformation)
        return ((CloudinaryDotNet.Transformation) o).Generate();
      throw new NotSupportedException(string.Format("Instance of type {0} is not supported as Transformation!", (object) o.GetType()));
    }
  }
}
