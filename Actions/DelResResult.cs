// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DelResResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class DelResResult : BaseResult
  {
    [DataMember(Name = "deleted")]
    public Dictionary<string, string> Deleted { get; protected set; }

    [DataMember(Name = "next_cursor")]
    public string NextCursor { get; protected set; }

    [DataMember(Name = "partial")]
    public bool Partial { get; protected set; }

    internal static DelResResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<DelResResult>(response);
    }
  }
}
