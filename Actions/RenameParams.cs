// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RenameParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class RenameParams : BaseParams
    {
        public RenameParams(string fromPublicId, string toPublicId)
        {
            FromPublicId = fromPublicId;
            ToPublicId = toPublicId;
        }

        public string FromPublicId { get; set; }

        public string ToPublicId { get; set; }

        public string Type { get; set; }

        public bool Overwrite { get; set; }

        public bool Invalidate { get; set; }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "from_public_id", FromPublicId);
            AddParam(paramsDictionary, "to_public_id", ToPublicId);
            AddParam(paramsDictionary, "overwrite", Overwrite);
            AddParam(paramsDictionary, "type", Type);
            AddParam(paramsDictionary, "invalidate", Invalidate);
            return paramsDictionary;
        }

        public override void Check()
        {
            if (string.IsNullOrEmpty(FromPublicId))
                throw new ArgumentException("FromPublicId can't be null!");
            if (string.IsNullOrEmpty(ToPublicId))
                throw new ArgumentException("ToPublicId can't be null!");
        }
    }
}