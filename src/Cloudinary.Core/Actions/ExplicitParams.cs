// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ExplicitParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CloudinaryDotNet.Actions
{
    public class ExplicitParams : BaseParams
    {
        public ExplicitParams(string publicId)
        {
            PublicId = publicId;
            Type = string.Empty;
            Tags = string.Empty;
        }

        public List<Transformation> EagerTransforms { get; set; }

        public bool? EagerAsync { get; set; }

        public string EagerNotificationUrl { get; set; }

        public string Type { get; set; }

        public string PublicId { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public string Tags { get; set; }

        public object FaceCoordinates { get; set; }

        public object CustomCoordinates { get; set; }

        public IDictionary<string, string> Context { get; set; }

        public List<ResponsiveBreakpoint> ResponsiveBreakpoints { get; set; }

        public bool Invalidate { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(PublicId))
                throw new ArgumentException("PublicId must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "tags", Tags);
            AddParam(paramsDictionary, "type", Type);
            AddParam(paramsDictionary, "eager_async", EagerAsync);
            AddParam(paramsDictionary, "eager_notification_url", EagerNotificationUrl);
            AddParam(paramsDictionary, "invalidate", Invalidate);
            AddCoordinates(paramsDictionary, "face_coordinates", FaceCoordinates);
            AddCoordinates(paramsDictionary, "custom_coordinates", CustomCoordinates);
            if (EagerTransforms != null)
                AddParam(paramsDictionary, "eager", string.Join("|", EagerTransforms.Select(t => t.Generate()).ToArray()));
            if (Context != null && Context.Count > 0)
                AddParam(paramsDictionary, "context", Context.ReducePiped());
            if (ResponsiveBreakpoints != null && ResponsiveBreakpoints.Count > 0)
                AddParam(paramsDictionary, "responsive_breakpoints", JsonConvert.SerializeObject(ResponsiveBreakpoints));
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