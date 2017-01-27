// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UpdateParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace CloudinaryDotNet.Actions
{
  public class UpdateParams : BaseParams
  {
    public string PublicId { get; set; }

    public ResourceType ResourceType { get; set; }

    public string Type { get; set; }

    public Dictionary<string, string> Headers { get; set; }

    public string Tags { get; set; }

    public StringDictionary Context { get; set; }

    public string RawConvert { get; set; }

    public object FaceCoordinates { get; set; }

    public object CustomCoordinates { get; set; }

    public string Categorization { get; set; }

    public string BackgroundRemoval { get; set; }

    public float? AutoTagging { get; set; }

    public string Detection { get; set; }

    public string SimilaritySearch { get; set; }

    public string Ocr { get; set; }

    public ModerationStatus ModerationStatus { get; set; }

    public UpdateParams(string publicId)
    {
      this.PublicId = publicId;
      this.Type = "upload";
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
      this.AddParam(paramsDictionary, "categorization", this.Categorization);
      this.AddParam(paramsDictionary, "detection", this.Detection);
      this.AddParam(paramsDictionary, "ocr", this.Ocr);
      this.AddParam(paramsDictionary, "similarity_search", this.SimilaritySearch);
      this.AddParam(paramsDictionary, "background_removal", this.BackgroundRemoval);
      if (this.ModerationStatus != ModerationStatus.Pending)
        this.AddParam(paramsDictionary, "moderation_status", Api.GetCloudinaryParam<ModerationStatus>(this.ModerationStatus));
      if (this.AutoTagging.HasValue)
        this.AddParam(paramsDictionary, "auto_tagging", this.AutoTagging.Value);
      this.AddParam(paramsDictionary, "raw_convert", this.RawConvert);
      if (this.Context != null && this.Context.Count > 0)
        this.AddParam(paramsDictionary, "context", string.Join("|", this.Context.Pairs));
      this.AddCoordinates(paramsDictionary, "face_coordinates", this.FaceCoordinates);
      this.AddCoordinates(paramsDictionary, "custom_coordinates", this.CustomCoordinates);
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
