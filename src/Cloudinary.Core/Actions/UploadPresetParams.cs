// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadPresetParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CloudinaryDotNet.Actions
{
    public class UploadPresetParams : BaseParams
    {
        public UploadPresetParams()
        {
        }

        public UploadPresetParams(GetUploadPresetResult preset)
        {
            Name = preset.Name;
            Unsigned = preset.Unsigned;
            if (preset.Settings == null)
                return;
            DisallowPublicId = preset.Settings.DisallowPublicId;
            Backup = preset.Settings.Backup;
            Type = preset.Settings.Type;
            if (preset.Settings.Tags != null)
                if (preset.Settings.Tags.Type == JTokenType.String)
                    Tags = preset.Settings.Tags.ToString();
                else if (preset.Settings.Tags.Type == JTokenType.Array)
                    Tags = string.Join(",", preset.Settings.Tags.Values<string>().ToArray());
            Invalidate = preset.Settings.Invalidate;
            UseFilename = preset.Settings.UseFilename;
            UniqueFilename = preset.Settings.UniqueFilename;
            DiscardOriginalFilename = preset.Settings.DiscardOriginalFilename;
            NotificationUrl = preset.Settings.NotificationUrl;
            Proxy = preset.Settings.Proxy;
            Folder = preset.Settings.Folder;
            Overwrite = preset.Settings.Overwrite;
            RawConvert = preset.Settings.RawConvert;
            if (preset.Settings.Context != null)
            {
                Context = new Dictionary<string, string>();
                foreach (JProperty jproperty in preset.Settings.Context)
                    Context.Add(jproperty.Name, jproperty.Value.ToString());
            }
            if (preset.Settings.AllowedFormats != null)
                if (preset.Settings.AllowedFormats.Type == JTokenType.String)
                    AllowedFormats = preset.Settings.AllowedFormats.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                else if (preset.Settings.AllowedFormats.Type == JTokenType.Array)
                    AllowedFormats = preset.Settings.AllowedFormats.Select(t => t.ToString()).ToArray();
            Moderation = preset.Settings.Moderation;
            Format = preset.Settings.Format;
            if (preset.Settings.Transformation != null)
                if (preset.Settings.Transformation.Type == JTokenType.String)
                {
                    Transformation = preset.Settings.Transformation.ToString();
                }
                else if (preset.Settings.Transformation.Type == JTokenType.Array)
                {
                    var transformParams = new Dictionary<string, object>();
                    foreach (JObject jobject in preset.Settings.Transformation)
                    foreach (var keyValuePair in jobject)
                        transformParams.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                    Transformation = new Transformation(transformParams);
                }
            if (preset.Settings.EagerTransforms != null)
            {
                EagerTransforms = new List<object>();
                foreach (var eagerTransform in preset.Settings.EagerTransforms)
                    if (eagerTransform.Type == JTokenType.String)
                    {
                        EagerTransforms.Add(eagerTransform.ToString());
                    }
                    else if (eagerTransform.Type == JTokenType.Array)
                    {
                        var transformParams = new Dictionary<string, object>();
                        foreach (JObject jobject in eagerTransform)
                        foreach (var keyValuePair in jobject)
                            transformParams.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                        EagerTransforms.Add(new Transformation(transformParams));
                    }
            }
            Exif = preset.Settings.Exif;
            Colors = preset.Settings.Colors;
            Faces = preset.Settings.Faces;
            if (preset.Settings.FaceCoordinates != null)
                if (preset.Settings.FaceCoordinates.Type == JTokenType.String)
                {
                    FaceCoordinates = preset.Settings.FaceCoordinates.ToString();
                }
                else if (preset.Settings.FaceCoordinates.Type == JTokenType.Array)
                {
                    var rectangleList = new List<Rectangle>();
                    foreach (var faceCoordinate in preset.Settings.FaceCoordinates)
                        rectangleList.Add(new Rectangle(faceCoordinate[0].Value<int>(), faceCoordinate[1].Value<int>(), faceCoordinate[2].Value<int>(), faceCoordinate[3].Value<int>()));
                }
            Metadata = preset.Settings.Metadata;
            EagerAsync = preset.Settings.EagerAsync;
            EagerNotificationUrl = preset.Settings.EagerNotificationUrl;
            Categorization = preset.Settings.Categorization;
            AutoTagging = preset.Settings.AutoTagging;
            Detection = preset.Settings.Detection;
            SimilaritySearch = preset.Settings.SimilaritySearch;
            Ocr = preset.Settings.Ocr;
        }

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

        public IDictionary<string, string> Context { get; set; }

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

        public override void Check()
        {
            if (Overwrite.HasValue && Overwrite.Value && Unsigned)
                throw new ArgumentException("Don't set both Overwrite and Unsigned to true!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "name", Name);
            AddParam(paramsDictionary, "unsigned", Unsigned);
            AddParam(paramsDictionary, "disallow_public_id", DisallowPublicId);
            AddParam(paramsDictionary, "type", Type);
            AddParam(paramsDictionary, "tags", Tags);
            AddParam(paramsDictionary, "use_filename", UseFilename);
            AddParam(paramsDictionary, "moderation", Moderation);
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
            AddParam(paramsDictionary, "invalidate", Invalidate);
            AddParam(paramsDictionary, "discard_original_filename", DiscardOriginalFilename);
            AddParam(paramsDictionary, "notification_url", NotificationUrl);
            AddParam(paramsDictionary, "proxy", Proxy);
            AddParam(paramsDictionary, "folder", Folder);
            AddParam(paramsDictionary, "raw_convert", RawConvert);
            AddParam(paramsDictionary, "backup", Backup);
            AddParam(paramsDictionary, "overwrite", Overwrite);
            AddParam(paramsDictionary, "unique_filename", UniqueFilename);
            AddParam(paramsDictionary, "transformation", GetTransformation(Transformation));
            if (AutoTagging.HasValue)
                AddParam(paramsDictionary, "auto_tagging", AutoTagging.Value);
            if (FaceCoordinates != null)
                AddParam(paramsDictionary, "face_coordinates", FaceCoordinates.ToString());
            if (EagerTransforms != null && EagerTransforms.Count > 0)
                AddParam(paramsDictionary, "eager", string.Join("|", EagerTransforms.Select(GetTransformation).ToArray()));
            if (AllowedFormats != null)
                AddParam(paramsDictionary, "allowed_formats", string.Join(",", AllowedFormats));
            if (Context != null && Context.Count > 0)
                AddParam(paramsDictionary, "context", Context.ReducePiped());
            return paramsDictionary;
        }

        private string GetTransformation(object o)
        {
            if (o == null)
                return null;
            if (o is string)
                return (string) o;
            if (o is Transformation)
                return ((Transformation) o).Generate();
            throw new NotSupportedException(string.Format("Instance of type {0} is not supported as Transformation!", o.GetType()));
        }
    }
}