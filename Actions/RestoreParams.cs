// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RestoreParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class RestoreParams : BaseParams
    {
        public List<string> PublicIds { get; set; } = new List<string>();

        private bool PublicIdsExist
        {
            get
            {
                if (PublicIds != null)
                    return PublicIds.Count > 0;
                return false;
            }
        }

        public ResourceType ResourceType { get; set; }

        public override void Check()
        {
            if (!PublicIdsExist)
                throw new ArgumentException("At least one PublicId must be specified!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (PublicIdsExist)
                paramsDictionary.Add("public_ids", PublicIds);
            return paramsDictionary;
        }
    }
}