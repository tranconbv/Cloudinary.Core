// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.VideoUploadResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class VideoUploadResult : RawUploadResult
    {
        [DataMember(Name = "width")]
        public int Width { get; protected set; }

        [DataMember(Name = "height")]
        public int Height { get; protected set; }

        [DataMember(Name = "format")]
        public string Format { get; protected set; }

        [DataMember(Name = "video")]
        public Video Video { get; protected set; }

        [DataMember(Name = "audio")]
        public Audio Audio { get; protected set; }

        [DataMember(Name = "frame_rate")]
        public double FrameRate { get; protected set; }

        [DataMember(Name = "bit_rate")]
        public int BitRate { get; protected set; }

        [DataMember(Name = "duration")]
        public double Duration { get; protected set; }

        internal new static Task<VideoUploadResult> Parse(HttpResponseMessage response)
        {
            return Parse<VideoUploadResult>(response);
        }
    }
}