// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DeletionParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class DeletionParams : BaseParams
    {
        public DeletionParams(string publicId)
        {
            Type = "upload";
            ResourceType = ResourceType.Image;
            PublicId = publicId;
        }

        public string PublicId { get; set; }

        public string Type { get; set; }

        public bool Invalidate { get; set; }

        public ResourceType ResourceType { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(PublicId))
                throw new ArgumentException("PublicId must be specified in UploadParams!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "type", Type);
            AddParam(paramsDictionary, "invalidate", Invalidate);
            return paramsDictionary;
        }
    }
}