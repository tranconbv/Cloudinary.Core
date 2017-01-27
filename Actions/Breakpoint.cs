// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.Breakpoint
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json;

namespace CloudinaryDotNet.Actions
{
    [JsonObject]
    public class Breakpoint
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("secure_url")]
        public string SecureUrl { get; set; }
    }
}