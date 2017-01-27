// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.VideoLayer
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;

namespace CloudinaryDotNet
{
  public class VideoLayer : BaseLayer<VideoLayer>
  {
    public VideoLayer()
    {
      this.m_resourceType = "video";
    }

    public VideoLayer(string publicId)
      : this()
    {
      this.PublicId(publicId);
    }

    public new VideoLayer ResourceType(string resourceType)
    {
      throw new InvalidOperationException("Cannot modify resourceType for video layers");
    }

    public new VideoLayer Type(string type)
    {
      throw new InvalidOperationException("Cannot modify type for video layers");
    }

    public new VideoLayer Format(string format)
    {
      throw new InvalidOperationException("Cannot modify format for video layers");
    }

    public override string ToString()
    {
      if (string.IsNullOrEmpty(this.m_publicId))
        throw new ArgumentException("Must supply publicId.");
      return base.ToString();
    }
  }
}
