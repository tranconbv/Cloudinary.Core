// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.UrlBuilder
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TzzRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet
{
    public class UrlBuilder : UriBuilder
    {
        private IDictionary<string, string> m_queryString;

        public UrlBuilder()
        {
        }

        public UrlBuilder(string uri)
            : base(uri)
        {
            PopulateQueryString();
        }

        public UrlBuilder(string uri, IDictionary<string, object> @params)
            : base(uri)
        {
            PopulateQueryString();
            SetParameters(@params);
        }

        public UrlBuilder(Uri uri)
            : base(uri)
        {
            PopulateQueryString();
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

        public IDictionary<string, string> QueryString
        {
            get
            {
                if (m_queryString == null)
                    m_queryString = new Dictionary<string, string>();
                return m_queryString;
            }
        }

        public string PageName
        {
            get
            {
                var path = Path;
                return path.Substring(path.LastIndexOf("/") + 1);
            }
            set
            {
                var path = Path;
                Path = path.Substring(0, path.LastIndexOf("/")) + "/" + value;
            }
        }

        //No aspx dotnet core
        //public UrlBuilder(Page page)
        //  : base(page.Request.Url.AbsoluteUri)
        //{
        //  this.PopulateQueryString();
        //}

        public void SetParameters(IDictionary<string, object> @params)
        {
            foreach (var keyValuePair in @params)
                if (keyValuePair.Value is IEnumerable<string>)
                    foreach (var str in (IEnumerable<string>) keyValuePair.Value)
                        QueryString.Add(keyValuePair.Key + "[]", str);
                else
                    QueryString[keyValuePair.Key] = keyValuePair.Value.ToString();
        }

        public new string ToString()
        {
            BuildQueryString();
            return Uri.AbsoluteUri;
        }

        public void Navigate()
        {
            _Navigate(true);
        }

        public void Navigate(bool endResponse)
        {
            _Navigate(endResponse);
        }

        private void _Navigate(bool endResponse)
        {
            throw new NotImplementedException("Needs to use IHttpContextAccassor, and is this even wanted?");
            //HttpContext.Current.Response.Redirect(this.ToString(), endResponse);
        }

        private void PopulateQueryString()
        {
            var query = Query;
            if (string.IsNullOrEmpty(query))
                return;
            if (m_queryString == null)
                m_queryString = new Dictionary<string, string>();
            m_queryString.Clear();
            var str1 = query.Substring(1);
            var chArray1 = new char[1] {'&'};
            foreach (var str2 in str1.Split(chArray1))
            {
                var chArray2 = new char[1] {'='};
                var strArray = str2.Split(chArray2);
                m_queryString[strArray[0]] = strArray.Length > 1 ? strArray[1] : string.Empty;
            }
        }

        private void BuildQueryString()
        {
            if (m_queryString == null)
                return;
            var count = m_queryString.Count;
            if (count == 0)
            {
                Query = string.Empty;
            }
            else
            {
                var array1 = new string[count];
                var array2 = new string[count];
                var strArray = new string[count];
                m_queryString.Keys.CopyTo(array1, 0);
                m_queryString.Values.CopyTo(array2, 0);
                for (var index = 0; index < count; ++index)
                    strArray[index] = array1[index] + "=" + array2[index];
                Query = string.Join("&", strArray);
            }
        }
    }
}