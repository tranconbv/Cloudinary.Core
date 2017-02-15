// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.SpriteResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class SpriteResult : BaseResult
    {
        [DataMember(Name = "css_url")]
        public Uri CssUri { get; protected set; }

        [DataMember(Name = "secure_css_url")]
        public Uri SecureCssUri { get; protected set; }

        [DataMember(Name = "image_url")]
        public Uri ImageUri { get; protected set; }

        [DataMember(Name = "json_url")]
        public Uri JsonUri { get; protected set; }

        [DataMember(Name = "public_id")]
        public string PublicId { get; protected set; }

        [DataMember(Name = "version")]
        public string Version { get; protected set; }

        [DataMember(Name = "image_infos")]
        public Dictionary<string, ImageInfo> ImageInfos { get; protected set; }

        internal static Task<SpriteResult> Parse(HttpResponseMessage response)
        {
            return Parse<SpriteResult>(response);
        }
    }
}