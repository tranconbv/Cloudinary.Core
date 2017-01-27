// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ExplodeParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class ExplodeParams : BaseParams
    {
        public ExplodeParams(string publicId, Transformation transformation)
        {
            PublicId = publicId;
            Transformation = transformation;
        }

        public string PublicId { get; set; }

        public Transformation Transformation { get; set; }

        public string NotificationUrl { get; set; }

        public string Format { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(PublicId))
                throw new ArgumentException("PublicId must be set!");
            if (Transformation == null)
                throw new ArgumentException("Transformation must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "notification_url", NotificationUrl);
            AddParam(paramsDictionary, "format", Format);
            if (Transformation != null)
                AddParam(paramsDictionary, "transformation", Transformation.Generate());
            return paramsDictionary;
        }
    }
}