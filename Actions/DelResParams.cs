// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.DelResParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class DelResParams : BaseParams
  {
    private List<string> m_publicIds = new List<string>();
    private string m_prefix;
    private string m_tag;
    private bool m_all;

    public ResourceType ResourceType { get; set; }

    public string Type { get; set; }

    public bool KeepOriginal { get; set; }

    public bool Invalidate { get; set; }

    public string NextCursor { get; set; }

    public List<string> PublicIds
    {
      get
      {
        return this.m_publicIds;
      }
      set
      {
        this.m_publicIds = value;
        this.m_prefix = string.Empty;
        this.m_tag = string.Empty;
        this.m_all = false;
      }
    }

    public string Prefix
    {
      get
      {
        return this.m_prefix;
      }
      set
      {
        this.m_publicIds = (List<string>) null;
        this.m_tag = string.Empty;
        this.m_prefix = value;
        this.m_all = false;
      }
    }

    public string Tag
    {
      get
      {
        return this.m_tag;
      }
      set
      {
        this.m_publicIds = (List<string>) null;
        this.m_prefix = string.Empty;
        this.m_tag = value;
        this.m_all = false;
      }
    }

    public bool All
    {
      get
      {
        return this.m_all;
      }
      set
      {
        this.m_publicIds = (List<string>) null;
        this.m_prefix = string.Empty;
        this.m_tag = string.Empty;
        this.m_all = true;
      }
    }

    public DelResParams()
    {
      this.Type = "upload";
    }

    public override void Check()
    {
      if ((this.PublicIds == null || this.PublicIds.Count == 0) && (string.IsNullOrEmpty(this.Prefix) && string.IsNullOrEmpty(this.Tag)) && !this.All)
        throw new ArgumentException("Either PublicIds or Prefix or Tag must be specified!");
      if (!string.IsNullOrEmpty(this.Tag) && !string.IsNullOrEmpty(this.Type))
        throw new ArgumentException("Type of resource cannot specified when tag is given!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "keep_original", this.KeepOriginal);
      this.AddParam(paramsDictionary, "invalidate", this.Invalidate);
      this.AddParam(paramsDictionary, "next_cursor", this.NextCursor);
      if (!string.IsNullOrEmpty(this.Tag))
        return paramsDictionary;
      if (!string.IsNullOrEmpty(this.Prefix))
        paramsDictionary.Add("prefix", (object) this.Prefix);
      else if (this.PublicIds != null && this.PublicIds.Count > 0)
        paramsDictionary.Add("public_ids", (object) this.PublicIds);
      if (this.m_all)
        this.AddParam(paramsDictionary, "all", true);
      return paramsDictionary;
    }
  }
}
