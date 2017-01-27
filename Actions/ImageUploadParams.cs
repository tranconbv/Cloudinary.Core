// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ImageUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CloudinaryDotNet.Actions
{
    public class ImageUploadParams : RawUploadParams
    {
        public ImageUploadParams()
        {
            Overwrite = new bool?();
            UniqueFilename = new bool?();
        }

        public string Format { get; set; }

        public Transformation Transformation { get; set; }

        public List<Transformation> EagerTransforms { get; set; }

        public new string Type
        {
            get { return base.Type; }
            set { base.Type = value; }
        }

        public override ResourceType ResourceType
        {
            get { return ResourceType.Image; }
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

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "format", Format);
            AddParam(paramsDictionary, "exif", Exif);
            AddParam(paramsDictionary, "faces", Faces);
            AddParam(paramsDictionary, "colors", Colors);
            AddParam(paramsDictionary, "image_metadata", Metadata);
            AddParam(paramsDictionary, "eager_async", EagerAsync);
            AddParam(paramsDictionary, "eager_notification_url", EagerNotificationUrl);
            AddParam(paramsDictionary, "categorization", Categorization);
            AddParam(paramsDictionary, "detection", Detection);
            AddParam(paramsDictionary, "ocr", Ocr);
            AddParam(paramsDictionary, "similarity_search", SimilaritySearch);
            AddParam(paramsDictionary, "upload_preset", UploadPreset);
            AddParam(paramsDictionary, "unsigned", Unsigned);
            AddParam(paramsDictionary, "phash", Phash);
            AddParam(paramsDictionary, "background_removal", BackgroundRemoval);
            AddParam(paramsDictionary, "return_delete_token", ReturnDeleteToken);
            if (AutoTagging.HasValue)
                AddParam(paramsDictionary, "auto_tagging", AutoTagging.Value);
            AddCoordinates(paramsDictionary, "face_coordinates", FaceCoordinates);
            AddCoordinates(paramsDictionary, "custom_coordinates", CustomCoordinates);
            if (Transformation != null)
                AddParam(paramsDictionary, "transformation", Transformation.Generate());
            if (EagerTransforms != null && EagerTransforms.Count > 0)
                AddParam(paramsDictionary, "eager", string.Join("|", EagerTransforms.Select(t => t.Generate()).ToArray()));
            if (ResponsiveBreakpoints != null && ResponsiveBreakpoints.Count > 0)
                AddParam(paramsDictionary, "responsive_breakpoints", JsonConvert.SerializeObject(ResponsiveBreakpoints));
            return paramsDictionary;
        }
    }
}