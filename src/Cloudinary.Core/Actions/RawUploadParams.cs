// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RawUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Text;

namespace CloudinaryDotNet.Actions
{
    public class RawUploadParams : BasicRawUploadParams
    {
        public RawUploadParams()
        {
            Overwrite = true;
            UniqueFilename = true;
            Context = new Dictionary<string, string>();
        }

        public string Tags { get; set; }

        public bool? Invalidate { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public bool? UseFilename { get; set; }

        public bool? UniqueFilename { get; set; }

        public bool? DiscardOriginalFilename { get; set; }

        public string NotificationUrl { get; set; }

        public string Proxy { get; set; }

        public string Folder { get; set; }

        public bool? Overwrite { get; set; }

        public string RawConvert { get; set; }

        public IDictionary<string, string> Context { get; set; }

        public string[] AllowedFormats { get; set; }

        public string Moderation { get; set; }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "tags", Tags);
            AddParam(paramsDictionary, "use_filename", UseFilename);
            AddParam(paramsDictionary, "moderation", Moderation);
            if (UseFilename.HasValue && UseFilename.Value)
                AddParam(paramsDictionary, "unique_filename", UniqueFilename);
            if (AllowedFormats != null)
                AddParam(paramsDictionary, "allowed_formats", string.Join(",", AllowedFormats));
            AddParam(paramsDictionary, "invalidate", Invalidate);
            AddParam(paramsDictionary, "discard_original_filename", DiscardOriginalFilename);
            AddParam(paramsDictionary, "notification_url", NotificationUrl);
            AddParam(paramsDictionary, "proxy", Proxy);
            AddParam(paramsDictionary, "folder", Folder);
            AddParam(paramsDictionary, "raw_convert", RawConvert);
            AddParam(paramsDictionary, "overwrite", Overwrite);
            if (Context != null && Context.Count > 0)
                AddParam(paramsDictionary, "context", Context.ReducePiped());
            if (Headers != null && Headers.Count > 0)
            {
                var stringBuilder = new StringBuilder();
                foreach (var header in Headers)
                    stringBuilder.AppendFormat("{0}: {1}\n", header.Key, header.Value);
                paramsDictionary.Add("headers", stringBuilder.ToString());
            }
            return paramsDictionary;
        }
    }
}