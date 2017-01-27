// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UsageResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class UsageResult : BaseResult
  {
    [DataMember(Name = "plan")]
    public string Plan { get; protected set; }

    [DataMember(Name = "last_updated")]
    public DateTime LastUpdated { get; protected set; }

    [DataMember(Name = "objects")]
    public Usage Objects { get; protected set; }

    [DataMember(Name = "bandwidth")]
    public Usage Bandwidth { get; protected set; }

    [DataMember(Name = "storage")]
    public Usage Storage { get; protected set; }

    [DataMember(Name = "requests")]
    public int Requests { get; protected set; }

    [DataMember(Name = "resources")]
    public int Resources { get; protected set; }

    [DataMember(Name = "derived_resources")]
    public int DerivedResources { get; protected set; }

    internal static UsageResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<UsageResult>(response);
    }
  }
}
