// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.BasicRawUploadParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class BasicRawUploadParams : BaseParams
    {
        public FileDescription File { get; set; }

        public string PublicId { get; set; }

        public bool? Backup { get; set; }

        public string Type { get; set; }

        public virtual ResourceType ResourceType
        {
            get { return ResourceType.Raw; }
        }

        public override void Check()
        {
            if (File == null)
                throw new ArgumentException("File must be specified in UploadParams!");
            if (!File.IsRemote && File.Stream == null && string.IsNullOrEmpty(File.FilePath))
                throw new ArgumentException("File is not ready!");
            if (string.IsNullOrEmpty(File.FileName))
                throw new ArgumentException("File name must be specified in UploadParams!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "type", Type);
            if (Backup.HasValue)
                AddParam(paramsDictionary, "backup", Backup.Value);
            return paramsDictionary;
        }
    }
}