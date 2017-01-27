// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ListSpecificResourcesParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class ListSpecificResourcesParams : ListResourcesParams
  {
    public List<string> PublicIds { get; set; }

    public ListSpecificResourcesParams()
    {
      this.PublicIds = new List<string>();
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.PublicIds != null && this.PublicIds.Count > 0)
      {
        this.AddParam(paramsDictionary, "public_ids", (IEnumerable<string>) this.PublicIds);
        if (paramsDictionary.ContainsKey("direction"))
          paramsDictionary.Remove("direction");
      }
      return paramsDictionary;
    }
  }
}
