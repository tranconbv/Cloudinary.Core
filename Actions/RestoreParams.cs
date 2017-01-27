// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.RestoreParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class RestoreParams : BaseParams
  {
    private List<string> m_publicIds = new List<string>();
    private ResourceType m_resourceType;

    public List<string> PublicIds
    {
      get
      {
        return this.m_publicIds;
      }
      set
      {
        this.m_publicIds = value;
      }
    }

    private bool PublicIdsExist
    {
      get
      {
        if (this.PublicIds != null)
          return this.PublicIds.Count > 0;
        return false;
      }
    }

    public ResourceType ResourceType
    {
      get
      {
        return this.m_resourceType;
      }
      set
      {
        this.m_resourceType = value;
      }
    }

    public override void Check()
    {
      if (!this.PublicIdsExist)
        throw new ArgumentException("At least one PublicId must be specified!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      if (this.PublicIdsExist)
        paramsDictionary.Add("public_ids", (object) this.PublicIds);
      return paramsDictionary;
    }
  }
}
