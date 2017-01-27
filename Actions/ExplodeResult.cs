// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ExplodeResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class ExplodeResult : BaseResult
    {
        [DataMember(Name = "status")]
        public string Status { get; protected set; }

        [DataMember(Name = "batch_id")]
        public string BatchId { get; protected set; }

        internal static ExplodeResult Parse(HttpWebResponse response)
        {
            return Parse<ExplodeResult>(response);
        }
    }
}