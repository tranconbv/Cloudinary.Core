// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadSettings
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class UploadSettings
  {
    [DataMember(Name = "disallow_public_id")]
    public bool DisallowPublicId { get; protected set; }

    [DataMember(Name = "backup")]
    public bool? Backup { get; protected set; }

    [DataMember(Name = "type")]
    public string Type { get; protected set; }

    [DataMember(Name = "tags")]
    public JToken Tags { get; protected set; }

    [DataMember(Name = "invalidate")]
    public bool Invalidate { get; protected set; }

    [DataMember(Name = "use_filename")]
    public bool UseFilename { get; protected set; }

    [DataMember(Name = "unique_filename")]
    public bool? UniqueFilename { get; protected set; }

    [DataMember(Name = "discard_original_filename")]
    public bool DiscardOriginalFilename { get; protected set; }

    [DataMember(Name = "notification_url")]
    public string NotificationUrl { get; protected set; }

    [DataMember(Name = "proxy")]
    public string Proxy { get; protected set; }

    [DataMember(Name = "folder")]
    public string Folder { get; protected set; }

    [DataMember(Name = "overwrite")]
    public bool? Overwrite { get; protected set; }

    [DataMember(Name = "raw_convert")]
    public string RawConvert { get; protected set; }

    [DataMember(Name = "context")]
    public JToken Context { get; protected set; }

    [DataMember(Name = "allowed_formats")]
    public JToken AllowedFormats { get; protected set; }

    [DataMember(Name = "moderation")]
    public string Moderation { get; protected set; }

    [DataMember(Name = "format")]
    public string Format { get; protected set; }

    [DataMember(Name = "transformation")]
    public JToken Transformation { get; protected set; }

    [DataMember(Name = "eager")]
    public JToken EagerTransforms { get; protected set; }

    [DataMember(Name = "exif")]
    public bool Exif { get; protected set; }

    [DataMember(Name = "colors")]
    public bool Colors { get; protected set; }

    [DataMember(Name = "faces")]
    public bool Faces { get; protected set; }

    [DataMember(Name = "face_coordinates")]
    public JToken FaceCoordinates { get; protected set; }

    [DataMember(Name = "image_metadata")]
    public bool Metadata { get; protected set; }

    [DataMember(Name = "eager_async")]
    public bool EagerAsync { get; protected set; }

    [DataMember(Name = "eager_notification_url")]
    public string EagerNotificationUrl { get; protected set; }

    [DataMember(Name = "categorization")]
    public string Categorization { get; protected set; }

    [DataMember(Name = "auto_tagging")]
    public float? AutoTagging { get; protected set; }

    [DataMember(Name = "detection")]
    public string Detection { get; protected set; }

    [DataMember(Name = "similarity_search")]
    public string SimilaritySearch { get; protected set; }

    [DataMember(Name = "ocr")]
    public string Ocr { get; protected set; }
  }
}
