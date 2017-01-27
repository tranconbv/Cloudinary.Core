// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.Resource
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class Resource : UploadResult
  {
    [DataMember(Name = "format")]
    public string Format { get; protected set; }

    [DataMember(Name = "resource_type")]
    public string ResourceType { get; protected set; }

    [DataMember(Name = "type")]
    public string Type { get; protected set; }

    [DataMember(Name = "created_at")]
    public string Created { get; protected set; }

    [DataMember(Name = "bytes")]
    public long Length { get; protected set; }

    [DataMember(Name = "width")]
    public int Width { get; protected set; }

    [DataMember(Name = "height")]
    public int Height { get; protected set; }

    [DataMember(Name = "tags")]
    public string[] Tags { get; protected set; }

    [DataMember(Name = "backup")]
    public bool? Backup { get; protected set; }

    [DataMember(Name = "moderation_status")]
    public CloudinaryDotNet.Actions.ModerationStatus? ModerationStatus { get; protected set; }

    [DataMember(Name = "context")]
    public JToken Context { get; protected set; }
  }
}
