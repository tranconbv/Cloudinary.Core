// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.CSource
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

namespace CloudinaryDotNet
{
  internal class CSource
  {
    public string Source;
    public string SourceToSign;

    public CSource(string source)
    {
      this.SourceToSign = this.Source = source;
    }

    public static CSource operator +(CSource src, string value)
    {
      src.Source += value;
      src.SourceToSign += value;
      return src;
    }
  }
}
