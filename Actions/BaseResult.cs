// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.BaseResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudinaryDotNet.Actions
{
    [DataContract]
    public abstract class BaseResult
    {
        public HttpStatusCode StatusCode { get; protected set; }

        public JToken JsonObj { get; protected set; }

        [DataMember(Name = "error")]
        public Error Error { get; protected set; }

        public long Limit { get; protected set; }

        public long Remaining { get; protected set; }

        public DateTime Reset { get; protected set; }

        internal static T Parse<T>(HttpWebResponse response) where T : BaseResult, new()
        {
            if (response == null)
                throw new ArgumentNullException("response");
            var obj = Activator.CreateInstance<T>();
            using (var responseStream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    var end = streamReader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(end);
                    obj.JsonObj = JToken.Parse(end);
                }
            }
            if (response.Headers != null)
                foreach (var allKey in response.Headers.AllKeys)
                    if (allKey.StartsWith("X-FeatureRateLimit"))
                    {
                        long result1;
                        if (allKey.EndsWith("Limit") && long.TryParse(response.Headers[allKey], out result1))
                            obj.Limit = result1;
                        if (allKey.EndsWith("Remaining") && long.TryParse(response.Headers[allKey], out result1))
                            obj.Remaining = result1;
                        DateTime result2;
                        if (allKey.EndsWith("Reset") && DateTime.TryParse(response.Headers[allKey], out result2))
                            obj.Reset = result2;
                    }
            obj.StatusCode = response.StatusCode;
            return obj;
        }
    }
}