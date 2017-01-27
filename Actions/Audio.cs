// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.Audio
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class Audio
  {
    [DataMember(Name = "codec")]
    public string Codec { get; protected set; }

    [DataMember(Name = "bit_rate")]
    public int? BitRate { get; protected set; }

    [DataMember(Name = "frequency")]
    public int? Frequency { get; protected set; }

    [DataMember(Name = "channels")]
    public int? Channels { get; protected set; }

    [DataMember(Name = "channel_layout")]
    public string ChannelLayout { get; protected set; }
  }
}
