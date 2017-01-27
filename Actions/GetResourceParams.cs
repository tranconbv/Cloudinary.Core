// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.GetResourceParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class GetResourceParams : BaseParams
    {
        public GetResourceParams(string publicId)
        {
            PublicId = publicId;
            Type = "upload";
            Exif = false;
            Colors = false;
            Faces = false;
        }

        public string PublicId { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Type { get; set; }

        public bool Exif { get; set; }

        public bool Colors { get; set; }

        public bool Faces { get; set; }

        public bool Metadata { get; set; }

        public bool Coordinates { get; set; }

        public int MaxResults { get; set; }

        public bool Phash { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(PublicId))
                throw new ArgumentException("PublicId must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            if (MaxResults > 0)
                AddParam(paramsDictionary, "max_results", MaxResults.ToString());
            AddParam(paramsDictionary, "exif", Exif);
            AddParam(paramsDictionary, "colors", Colors);
            AddParam(paramsDictionary, "faces", Faces);
            AddParam(paramsDictionary, "image_metadata", Metadata);
            AddParam(paramsDictionary, "phash", Phash);
            AddParam(paramsDictionary, "coordinates", Coordinates);
            return paramsDictionary;
        }
    }
}