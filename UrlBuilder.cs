// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.UrlBuilder
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet
{
  public class UrlBuilder : UriBuilder
  {
    private StringDictionary m_queryString;

    public StringDictionary QueryString
    {
      get
      {
        if (this.m_queryString == null)
          this.m_queryString = new StringDictionary();
        return this.m_queryString;
      }
    }

    public string PageName
    {
      get
      {
        string path = this.Path;
        return path.Substring(path.LastIndexOf("/") + 1);
      }
      set
      {
        string path = this.Path;
        this.Path = path.Substring(0, path.LastIndexOf("/")) + "/" + value;
      }
    }

    public UrlBuilder()
    {
    }

    public UrlBuilder(string uri)
      : base(uri)
    {
      this.PopulateQueryString();
    }

    public UrlBuilder(string uri, IDictionary<string, object> @params)
      : base(uri)
    {
      this.PopulateQueryString();
      this.SetParameters(@params);
    }

    public UrlBuilder(Uri uri)
      : base(uri)
    {
      this.PopulateQueryString();
    }

    public UrlBuilder(string schemeName, string hostName)
      : base(schemeName, hostName)
    {
    }

    public UrlBuilder(string scheme, string host, int portNumber)
      : base(scheme, host, portNumber)
    {
    }

    public UrlBuilder(string scheme, string host, int port, string pathValue)
      : base(scheme, host, port, pathValue)
    {
    }

    public UrlBuilder(string scheme, string host, int port, string path, string extraValue)
      : base(scheme, host, port, path, extraValue)
    {
    }

    //No aspx dotnet core
    //public UrlBuilder(Page page)
    //  : base(page.Request.Url.AbsoluteUri)
    //{
    //  this.PopulateQueryString();
    //}

    public void SetParameters(IDictionary<string, object> @params)
    {
      foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) @params)
      {
        if (keyValuePair.Value is IEnumerable<string>)
        {
          foreach (string str in (IEnumerable<string>) keyValuePair.Value)
            this.QueryString.Add(keyValuePair.Key + "[]", str);
        }
        else
          this.QueryString[keyValuePair.Key] = keyValuePair.Value.ToString();
      }
    }

    public new string ToString()
    {
      this.BuildQueryString();
      return this.Uri.AbsoluteUri;
    }

    public void Navigate()
    {
      this._Navigate(true);
    }

    public void Navigate(bool endResponse)
    {
      this._Navigate(endResponse);
    }

    private void _Navigate(bool endResponse)
    {
      throw new NotImplementedException("Needs to use IHttpContextAccassor, and is this even wanted?");
      //HttpContext.Current.Response.Redirect(this.ToString(), endResponse);
    }

    private void PopulateQueryString()
    {
      string query = this.Query;
      if (query == string.Empty || query == null)
        return;
      if (this.m_queryString == null)
        this.m_queryString = new StringDictionary();
      this.m_queryString.Clear();
      string str1 = query.Substring(1);
      char[] chArray1 = new char[1]{ '&' };
      foreach (string str2 in str1.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ '=' };
        string[] strArray = str2.Split(chArray2);
        this.m_queryString[strArray[0]] = strArray.Length > 1 ? strArray[1] : string.Empty;
      }
    }

    private void BuildQueryString()
    {
      if (this.m_queryString == null)
        return;
      int count = this.m_queryString.Count;
      if (count == 0)
      {
        this.Query = string.Empty;
      }
      else
      {
        string[] array1 = new string[count];
        string[] array2 = new string[count];
        string[] strArray = new string[count];
        this.m_queryString.Keys.CopyTo(array1, 0);
        this.m_queryString.Values.CopyTo(array2, 0);
        for (int index = 0; index < count; ++index)
          strArray[index] = array1[index] + "=" + array2[index];
        this.Query = string.Join("&", strArray);
      }
    }
  }
}
