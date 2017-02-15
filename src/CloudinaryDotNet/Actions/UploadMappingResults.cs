// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadMappingResults
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public class UploadMappingResults : BaseResult
    {
        public string Message { get; protected set; }

        public Dictionary<string, string> Mappings { get; protected set; }

        public string NextCursor { get; protected set; }

        internal static async Task<UploadMappingResults> Parse(HttpResponseMessage response)
        {
            var uploadMappingResults = await Parse<UploadMappingResults>(response);
            if (uploadMappingResults.Mappings == null)
                uploadMappingResults.Mappings = new Dictionary<string, string>();
            if (uploadMappingResults.JsonObj != null)
            {
                var str1 = uploadMappingResults.JsonObj.Value<string>("message") ?? string.Empty;
                uploadMappingResults.Message = str1;
                var jtoken = uploadMappingResults.JsonObj["mappings"];
                if (jtoken != null)
                    foreach (var child in jtoken.Children())
                        uploadMappingResults.Mappings.Add(child["folder"].ToString(), child["template"].ToString());
                var key = uploadMappingResults.JsonObj.Value<string>("folder") ?? string.Empty;
                var str2 = uploadMappingResults.JsonObj.Value<string>("template") ?? string.Empty;
                if (!string.IsNullOrEmpty(key))
                    uploadMappingResults.Mappings.Add(key, str2);
                uploadMappingResults.NextCursor = uploadMappingResults.JsonObj.Value<string>("next_cursor") ?? string.Empty;
            }
            return uploadMappingResults;
        }
    }
}