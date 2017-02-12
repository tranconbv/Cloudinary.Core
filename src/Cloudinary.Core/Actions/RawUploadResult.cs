// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RawUploadResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class RawUploadResult : UploadResult
    {
        [DataMember(Name = "signature")]
        public string Signature { get; protected set; }

        [DataMember(Name = "resource_type")]
        public string ResourceType { get; protected set; }

        [DataMember(Name = "bytes")]
        public long Length { get; protected set; }

        [DataMember(Name = "moderation")]
        public List<Moderation> Moderation { get; protected set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; protected set; }

        [DataMember(Name = "tags")]
        public string[] Tags { get; protected set; }

        internal static RawUploadResult Parse(HttpWebResponse response)
        {
            return Parse<RawUploadResult>(response);
        }
    }
}