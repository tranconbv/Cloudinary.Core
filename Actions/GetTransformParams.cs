// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.GetTransformParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class GetTransformParams : BaseParams
    {
        public GetTransformParams()
        {
            Transformation = string.Empty;
        }

        public string Transformation { get; set; }

        public int MaxResults { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Transformation))
                throw new ArgumentException("Transformation must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (MaxResults > 0)
                AddParam(paramsDictionary, "max_results", MaxResults.ToString());
            return paramsDictionary;
        }
    }
}