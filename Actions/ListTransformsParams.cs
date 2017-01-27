// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListTransformsParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class ListTransformsParams : BaseParams
    {
        public ListTransformsParams()
        {
            NextCursor = string.Empty;
        }

        public int MaxResults { get; set; }

        public string NextCursor { get; set; }

        public override void Check()
        {
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (MaxResults > 0)
                AddParam(paramsDictionary, "max_results", MaxResults.ToString());
            AddParam(paramsDictionary, "next_cursor", NextCursor);
            return paramsDictionary;
        }
    }
}