// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListResourcesParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class ListResourcesParams : BaseParams
    {
        public ResourceType ResourceType { get; set; }

        public string Type { get; set; }

        public int MaxResults { get; set; }

        public bool Tags { get; set; }

        public bool Moderations { get; set; }

        public bool Context { get; set; }

        public string NextCursor { get; set; }

        public string Direction { get; set; }

        public DateTime StartAt { get; set; }

        public override void Check()
        {
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (MaxResults > 0)
                AddParam(paramsDictionary, "max_results", MaxResults.ToString());
            AddParam(paramsDictionary, "start_at", StartAt);
            AddParam(paramsDictionary, "next_cursor", NextCursor);
            AddParam(paramsDictionary, "tags", Tags);
            AddParam(paramsDictionary, "moderations", Moderations);
            AddParam(paramsDictionary, "context", Context);
            AddParam(paramsDictionary, "direction", Direction);
            AddParam(paramsDictionary, "type", Type);
            return paramsDictionary;
        }
    }
}