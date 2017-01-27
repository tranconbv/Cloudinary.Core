// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RawPartUploadResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class RawPartUploadResult : RawUploadResult
  {
    [DataMember(Name = "upload_id")]
    public string UploadId { get; protected set; }

    internal static RawPartUploadResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<RawPartUploadResult>(response);
    }
  }
}
