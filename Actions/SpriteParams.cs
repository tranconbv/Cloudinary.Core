// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.SpriteParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class SpriteParams : BaseParams
    {
        public SpriteParams(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; set; }

        public Transformation Transformation { get; set; }

        public string NotificationUrl { get; set; }

        public bool Async { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Tag))
                throw new ArgumentException("Tag must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "tag", Tag);
            AddParam(paramsDictionary, "notification_url", NotificationUrl);
            AddParam(paramsDictionary, "async", Async);
            if (Transformation != null)
                AddParam(paramsDictionary, "transformation", Transformation.Generate());
            return paramsDictionary;
        }
    }
}