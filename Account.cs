// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Account
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;

namespace CloudinaryDotNet
{
  [Serializable]
  public class Account
  {
    public string Cloud { get; set; }

    public string ApiKey { get; set; }

    public string ApiSecret { get; set; }

    public Account()
    {
    }

    public Account(string cloud, string apiKey, string apiSecret)
    {
      this.Cloud = cloud;
      this.ApiKey = apiKey;
      this.ApiSecret = apiSecret;
    }

    public Account(string cloud)
    {
      this.Cloud = cloud;
    }
  }
}
