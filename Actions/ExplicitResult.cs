// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ExplicitResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class ExplicitResult : RawUploadResult
  {
    [DataMember(Name = "format")]
    public string Format { get; protected set; }

    [DataMember(Name = "type")]
    public string Type { get; protected set; }

    [DataMember(Name = "eager")]
    public CloudinaryDotNet.Actions.Eager[] Eager { get; protected set; }

    public List<ResponsiveBreakpointList> ResponsiveBreakpoints { get; set; }

    internal static ExplicitResult Parse(HttpWebResponse response)
    {
      ExplicitResult explicitResult = BaseResult.Parse<ExplicitResult>(response);
      if (explicitResult.JsonObj != null)
      {
        JToken jtoken = explicitResult.JsonObj[(object) "responsive_breakpoints"];
        if (jtoken != null)
          explicitResult.ResponsiveBreakpoints = jtoken.ToObject<List<ResponsiveBreakpointList>>();
      }
      return explicitResult;
    }
  }
}
