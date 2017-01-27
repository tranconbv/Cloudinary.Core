// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.CreateTransformParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class CreateTransformParams : BaseParams
    {
        public string Name { get; set; }

        public Transformation Transform { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Name must be set!");
            if (Transform == null)
                throw new ArgumentException("Transform must be defined!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            paramsDictionary.Add("transformation", Transform.Generate());
            return paramsDictionary;
        }
    }
}