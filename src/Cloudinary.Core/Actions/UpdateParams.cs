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
        public UpdateParams(string publicId)
        {
            PublicId = publicId;
            Type = "upload";
        }

        public string PublicId { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public string Tags { get; set; }

        public IDictionary<string, string> Context { get; set; }

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

        public override void Check()
        {
            if (string.IsNullOrEmpty(PublicId))
                throw new ArgumentException("PublicId must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "tags", Tags);
            AddParam(paramsDictionary, "type", Type);
            AddParam(paramsDictionary, "categorization", Categorization);
            AddParam(paramsDictionary, "detection", Detection);
            AddParam(paramsDictionary, "ocr", Ocr);
            AddParam(paramsDictionary, "similarity_search", SimilaritySearch);
            AddParam(paramsDictionary, "background_removal", BackgroundRemoval);
            if (ModerationStatus != ModerationStatus.Pending)
                AddParam(paramsDictionary, "moderation_status", Api.GetCloudinaryParam(ModerationStatus));
            if (AutoTagging.HasValue)
                AddParam(paramsDictionary, "auto_tagging", AutoTagging.Value);
            AddParam(paramsDictionary, "raw_convert", RawConvert);
            if (Context != null && Context.Count > 0)
                AddParam(paramsDictionary, "context", Context.ReducePiped());
            AddCoordinates(paramsDictionary, "face_coordinates", FaceCoordinates);
            AddCoordinates(paramsDictionary, "custom_coordinates", CustomCoordinates);
            if (Headers != null && Headers.Count > 0)
            {
                var stringBuilder = new StringBuilder();
                foreach (var header in Headers)
                    stringBuilder.AppendFormat("{0}: {1}\n", header.Key, header.Value);
                paramsDictionary.Add("headers", stringBuilder.ToString());
            }
            return paramsDictionary;
        }
    }
}