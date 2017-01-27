// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadMappingResults
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
  public class UploadMappingResults : BaseResult
  {
    public string Message { get; protected set; }

    public Dictionary<string, string> Mappings { get; protected set; }

    public string NextCursor { get; protected set; }

    internal static UploadMappingResults Parse(HttpWebResponse response)
    {
      UploadMappingResults uploadMappingResults = BaseResult.Parse<UploadMappingResults>(response);
      if (uploadMappingResults.Mappings == null)
        uploadMappingResults.Mappings = new Dictionary<string, string>();
      if (uploadMappingResults.JsonObj != null)
      {
        string str1 = uploadMappingResults.JsonObj.Value<string>((object) "message") ?? string.Empty;
        uploadMappingResults.Message = str1;
        JToken jtoken = uploadMappingResults.JsonObj[(object) "mappings"];
        if (jtoken != null)
        {
          foreach (JToken child in jtoken.Children())
            uploadMappingResults.Mappings.Add(child[(object) "folder"].ToString(), child[(object) "template"].ToString());
        }
        string key = uploadMappingResults.JsonObj.Value<string>((object) "folder") ?? string.Empty;
        string str2 = uploadMappingResults.JsonObj.Value<string>((object) "template") ?? string.Empty;
        if (!string.IsNullOrEmpty(key))
          uploadMappingResults.Mappings.Add(key, str2);
        uploadMappingResults.NextCursor = uploadMappingResults.JsonObj.Value<string>((object) "next_cursor") ?? string.Empty;
      }
      return uploadMappingResults;
    }
  }
}
