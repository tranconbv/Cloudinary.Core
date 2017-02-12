// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListResourcesByModerationParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class ListResourcesByModerationParams : ListResourcesParams
    {
        public string ModerationKind { get; set; }

        public ModerationStatus ModerationStatus { get; set; }

        public override void Check()
        {
            base.Check();
            if (string.IsNullOrEmpty(ModerationKind))
                throw new ArgumentException("ModerationKind must be set to filter resources by moderation kind/status!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (paramsDictionary.ContainsKey("type"))
                paramsDictionary.Remove("type");
            return paramsDictionary;
        }
    }
}