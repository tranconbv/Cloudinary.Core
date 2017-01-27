// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.MultiResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class MultiResult : BaseResult
  {
    [DataMember(Name = "url")]
    public Uri Uri { get; protected set; }

    [DataMember(Name = "secure_url")]
    public Uri SecureUri { get; protected set; }

    [DataMember(Name = "public_id")]
    public string PublicId { get; protected set; }

    [DataMember(Name = "version")]
    public string Version { get; protected set; }

    internal static MultiResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<MultiResult>(response);
    }
  }
}
