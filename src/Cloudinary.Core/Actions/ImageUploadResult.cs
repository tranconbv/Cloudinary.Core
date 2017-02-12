// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ImageUploadResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class ImageUploadResult : RawUploadResult
    {
        [DataMember(Name = "width")]
        public int Width { get; protected set; }

        [DataMember(Name = "height")]
        public int Height { get; protected set; }

        [DataMember(Name = "format")]
        public string Format { get; protected set; }

        [DataMember(Name = "exif")]
        public Dictionary<string, string> Exif { get; protected set; }

        [DataMember(Name = "image_metadata")]
        public Dictionary<string, string> Metadata { get; protected set; }

        [DataMember(Name = "faces")]
        public int[][] Faces { get; protected set; }

        [DataMember(Name = "colors")]
        public string[][] Colors { get; protected set; }

        [DataMember(Name = "phash")]
        public string Phash { get; protected set; }

        [DataMember(Name = "delete_token")]
        public string DeleteToken { get; protected set; }

        [DataMember(Name = "info")]
        public Info Info { get; protected set; }

        public List<ResponsiveBreakpointList> ResponsiveBreakpoints { get; set; }

        internal static ImageUploadResult Parse(HttpWebResponse response)
        {
            var imageUploadResult = Parse<ImageUploadResult>(response);
            if (imageUploadResult.JsonObj != null)
            {
                var jtoken = imageUploadResult.JsonObj["responsive_breakpoints"];
                if (jtoken != null)
                    imageUploadResult.ResponsiveBreakpoints = jtoken.ToObject<List<ResponsiveBreakpointList>>();
            }
            return imageUploadResult;
        }
    }
}