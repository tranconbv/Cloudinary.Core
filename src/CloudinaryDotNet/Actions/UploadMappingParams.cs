// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UploadMappingParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class UploadMappingParams : BaseParams
    {
        public string NextCursor { get; set; }

        public int MaxResults { get; set; }

        public string Folder { get; set; }

        public string Template { get; set; }

        public override void Check()
        {
            if (MaxResults > 500)
                throw new ArgumentException(string.Format("The maximal count of folders to return is 500, but {0} given!", MaxResults));
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "folder", Folder);
            AddParam(paramsDictionary, "template", Template);
            if (MaxResults > 0)
                AddParam(paramsDictionary, "max_results", MaxResults);
            if (!string.IsNullOrEmpty(NextCursor))
                AddParam(paramsDictionary, "next_cursor", NextCursor);
            return paramsDictionary;
        }
    }
}