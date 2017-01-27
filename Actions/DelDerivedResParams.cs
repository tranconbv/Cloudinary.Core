// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DelDerivedResParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class DelDerivedResParams : BaseParams
  {
    public List<string> DerivedResources { get; set; }

    public DelDerivedResParams()
    {
      this.DerivedResources = new List<string>();
    }

    public override void Check()
    {
      if (this.DerivedResources == null)
        throw new ArgumentException("DerivedResources can't be null!");
      if (this.DerivedResources.Count == 0)
        throw new ArgumentException("At least one derived resource must be specified!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.DerivedResources != null && this.DerivedResources.Count > 0)
        paramsDictionary.Add("derived_resource_ids", (object) this.DerivedResources);
      return paramsDictionary;
    }
  }
}
