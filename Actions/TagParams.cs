// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.TagParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class TagParams : BaseParams
    {
        public List<string> PublicIds { get; set; } = new List<string>();

        public string Tag { get; set; }

        public string Type { get; set; }

        public TagCommand Command { get; set; }

        public override void Check()
        {
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "tag", Tag);
            AddParam(paramsDictionary, "public_ids", PublicIds);
            AddParam(paramsDictionary, "command", Api.GetCloudinaryParam(Command));
            return paramsDictionary;
        }
    }
}