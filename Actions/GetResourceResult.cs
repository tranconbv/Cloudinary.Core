// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.GetResourceResult
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
  public class GetResourceResult : BaseResult
  {
    [DataMember(Name = "resource_type")]
    protected string m_resourceType;

    [DataMember(Name = "public_id")]
    public string PublicId { get; protected set; }

    [DataMember(Name = "format")]
    public string Format { get; protected set; }

    [DataMember(Name = "version")]
    public string Version { get; protected set; }

    public ResourceType ResourceType
    {
      get
      {
        return Api.ParseCloudinaryParam<ResourceType>(this.m_resourceType);
      }
    }

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

    [DataMember(Name = "url")]
    public string Url { get; protected set; }

    [DataMember(Name = "secure_url")]
    public string SecureUrl { get; protected set; }

    [DataMember(Name = "next_cursor")]
    public string NextCursor { get; protected set; }

    [DataMember(Name = "exif")]
    public Dictionary<string, string> Exif { get; protected set; }

    [DataMember(Name = "image_metadata")]
    public Dictionary<string, string> Metadata { get; protected set; }

    [DataMember(Name = "faces")]
    public int[][] Faces { get; protected set; }

    [DataMember(Name = "colors")]
    public string[][] Colors { get; protected set; }

    [DataMember(Name = "derived")]
    public CloudinaryDotNet.Actions.Derived[] Derived { get; protected set; }

    [DataMember(Name = "tags")]
    public string[] Tags { get; protected set; }

    [DataMember(Name = "moderation")]
    public List<CloudinaryDotNet.Actions.Moderation> Moderation { get; protected set; }

    [DataMember(Name = "context")]
    public JToken Context { get; protected set; }

    [DataMember(Name = "phash")]
    public string Phash { get; protected set; }

    [DataMember(Name = "predominant")]
    public Predominant Predominant { get; protected set; }

    [DataMember(Name = "coordinates")]
    public Coordinates Coordinates { get; protected set; }

    [DataMember(Name = "info")]
    public Info Info { get; protected set; }

    internal static GetResourceResult Parse(HttpWebResponse response)
    {
      return BaseResult.Parse<GetResourceResult>(response);
    }
  }
}
