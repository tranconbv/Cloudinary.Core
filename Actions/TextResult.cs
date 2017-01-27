// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.TextResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Net;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class TextResult : BaseResult
  {
    [DataMember(Name = "width")]
    public int Width { get; protected set; }

    [DataMember(Name = "height")]
    public int Height { get; protected set; }

    internal static TextResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<TextResult>(response);
    }
  }
}
