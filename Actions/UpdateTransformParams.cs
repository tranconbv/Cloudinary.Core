// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.UpdateTransformParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
    public class UpdateTransformParams : BaseParams
    {
        public UpdateTransformParams()
        {
            Transformation = string.Empty;
        }

        public string Transformation { get; set; }

        public Transformation UnsafeTransform { get; set; }

        public bool Strict { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Transformation))
                throw new ArgumentException("Transformation must be set!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "allowed_for_strict", Strict ? "true" : "false");
            if (UnsafeTransform != null)
                AddParam(paramsDictionary, "unsafe_update", UnsafeTransform.Generate());
            return paramsDictionary;
        }
    }
}