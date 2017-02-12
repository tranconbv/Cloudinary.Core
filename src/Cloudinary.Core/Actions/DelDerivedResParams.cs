// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DelDerivedResParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class DelDerivedResParams : BaseParams
    {
        public DelDerivedResParams()
        {
            DerivedResources = new List<string>();
        }

        public List<string> DerivedResources { get; set; }

        public override void Check()
        {
            if (DerivedResources == null)
                throw new ArgumentException("DerivedResources can't be null!");
            if (DerivedResources.Count == 0)
                throw new ArgumentException("At least one derived resource must be specified!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (DerivedResources != null && DerivedResources.Count > 0)
                paramsDictionary.Add("derived_resource_ids", DerivedResources);
            return paramsDictionary;
        }
    }
}