// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.Derived
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class Derived
  {
    [DataMember(Name = "transformation")]
    public string Transformation { get; protected set; }

    [DataMember(Name = "format")]
    public string Format { get; protected set; }

    [DataMember(Name = "bytes")]
    public long Length { get; protected set; }

    [DataMember(Name = "id")]
    public string Id { get; protected set; }

    [DataMember(Name = "url")]
    public string Url { get; protected set; }

    [DataMember(Name = "secure_url")]
    public string SecureUrl { get; protected set; }
  }
}
