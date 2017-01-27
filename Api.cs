// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Api
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CloudinaryDotNet
{
  public class Api : ISignProvider
  {
    private string m_apiAddr = "https://api.cloudinary.com";
    public Func<string, HttpWebRequest> RequestBuilder = (Func<string, HttpWebRequest>) (x => WebRequest.Create(x) as HttpWebRequest);
    public bool UseChunkedEncoding = true;
    public int ChunkSize = 65000;
    public const string ADDR_API = "api.cloudinary.com";
    public const string ADDR_RES = "res.cloudinary.com";
    public const string API_VERSION = "v1_1";
    public const string HTTP_BOUNDARY = "notrandomsequencetouseasboundary";
    public static readonly string USER_AGENT;
    public bool CSubDomain;
    public bool ShortenUrl;
    public bool UseRootPath;
    public bool UsePrivateCdn;
    public string PrivateCdn;
    public string Suffix;
    public string UserPlatform;
    public int Timeout;

    public Account Account { get; private set; }

    public string ApiBaseAddress
    {
      get
      {
        return this.m_apiAddr;
      }
      set
      {
        this.m_apiAddr = value;
      }
    }

    public Url Url
    {
      get
      {
        return new Url(this.Account.Cloud, (ISignProvider) this).CSubDomain(this.CSubDomain).Shorten(this.ShortenUrl).PrivateCdn(this.UsePrivateCdn).Secure(this.UsePrivateCdn).SecureDistribution(this.PrivateCdn);
      }
    }

    public Url UrlImgUp
    {
      get
      {
        return this.Url.ResourceType("image").Action("upload").UseRootPath(this.UseRootPath).Suffix(this.Suffix);
      }
    }

    public Url UrlVideoUp
    {
      get
      {
        return this.Url.ResourceType("video").Action("upload").UseRootPath(this.UseRootPath).Suffix(this.Suffix);
      }
    }

    public Url ApiUrl
    {
      get
      {
        return this.Url.CloudinaryAddr(this.m_apiAddr);
      }
    }

    public Url ApiUrlImgUp
    {
      get
      {
        return this.ApiUrl.Action("upload").ResourceType("image");
      }
    }

    public Url ApiUrlV
    {
      get
      {
        return this.ApiUrl.ApiVersion("v1_1");
      }
    }

    public Url ApiUrlImgUpV
    {
      get
      {
        return this.ApiUrlV.Action("upload").ResourceType("image");
      }
    }

    public Url ApiUrlVideoUpV
    {
      get
      {
        return this.ApiUrlV.Action("upload").ResourceType("video");
      }
    }

    static Api()
    {
      Version version = Assembly.GetExecutingAssembly().GetName().Version;
      Api.USER_AGENT = string.Format("CloudinaryDotNet/{0}.{1}.{2}", (object) version.Major, (object) version.Minor, (object) version.Build);
    }

    public Api()
      : this(Environment.GetEnvironmentVariable("CLOUDINARY_URL"))
    {
    }

    public Api(string cloudinaryUrl)
    {
      if (string.IsNullOrEmpty(cloudinaryUrl))
        throw new ArgumentException("Valid cloudinary init string must be provided!");
      Uri uri = new Uri(cloudinaryUrl);
      if (string.IsNullOrEmpty(uri.Host))
        throw new ArgumentException("Cloud name must be specified as host name in URL!");
      string[] strArray = uri.UserInfo.Split(':');
      this.Account = new Account(uri.Host, strArray[0], strArray[1]);
      this.UsePrivateCdn = !string.IsNullOrEmpty(uri.AbsolutePath) && uri.AbsolutePath != "/";
      this.PrivateCdn = string.Empty;
      if (!this.UsePrivateCdn)
        return;
      this.PrivateCdn = uri.AbsolutePath;
    }

    public Api(Account account, bool usePrivateCdn, string privateCdn, bool shortenUrl, bool cSubDomain)
      : this(account)
    {
      this.UsePrivateCdn = usePrivateCdn;
      this.PrivateCdn = privateCdn;
      this.ShortenUrl = shortenUrl;
      this.CSubDomain = cSubDomain;
    }

    public Api(Account account)
    {
      if (account == null)
        throw new ArgumentException("Account can't be null!");
      if (string.IsNullOrEmpty(account.Cloud))
        throw new ArgumentException("Cloud name must be specified in Account!");
      this.UsePrivateCdn = false;
      this.Account = account;
    }

    public static string GetCloudinaryParam<T>(T e)
    {
      DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) typeof (T).GetField(e.ToString()).GetCustomAttributes(typeof (DescriptionAttribute), false);
      if (customAttributes.Length == 0)
        throw new ArgumentException("Enum fields must be decorated with DescriptionAttribute!");
      return customAttributes[0].Description;
    }

    public static T ParseCloudinaryParam<T>(string s)
    {
      foreach (FieldInfo field in typeof (T).GetFields())
      {
        DescriptionAttribute[] customAttributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof (DescriptionAttribute), false);
        if (customAttributes.Length != 0 && s == customAttributes[0].Description)
          return (T) field.GetValue((object) null);
      }
      return default (T);
    }

    public HttpWebResponse Call(HttpMethod method, string url, SortedDictionary<string, object> parameters, FileDescription file, Dictionary<string, string> extraHeaders = null)
    {
      HttpWebRequest httpWebRequest = this.RequestBuilder(url);
      httpWebRequest.Method = Enum.GetName(typeof (HttpMethod), (object) method);
      httpWebRequest.UserAgent = string.IsNullOrEmpty(this.UserPlatform) ? Api.USER_AGENT : string.Format("{0} {1}", (object) this.UserPlatform, (object) Api.USER_AGENT);
      if (this.Timeout > 0)
        httpWebRequest.Timeout = this.Timeout;
      byte[] bytes = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", (object) this.Account.ApiKey, (object) this.Account.ApiSecret));
      httpWebRequest.Headers.Add("Authorization", string.Format("Basic {0}", (object) Convert.ToBase64String(bytes)));
      if (extraHeaders != null)
      {
        foreach (KeyValuePair<string, string> extraHeader in extraHeaders)
          httpWebRequest.Headers[extraHeader.Key] = extraHeader.Value;
      }
      if (method != HttpMethod.POST)
      {
        if (method != HttpMethod.PUT)
          goto label_40;
      }
      if (parameters != null)
      {
        httpWebRequest.AllowWriteStreamBuffering = false;
        httpWebRequest.AllowAutoRedirect = false;
        if (this.UseChunkedEncoding)
          httpWebRequest.SendChunked = true;
        httpWebRequest.ContentType = "multipart/form-data; boundary=notrandomsequencetouseasboundary";
        if (!parameters.ContainsKey("unsigned") || parameters["unsigned"].ToString() == "false")
          this.FinalizeUploadParameters((IDictionary<string, object>) parameters);
        using (Stream requestStream = httpWebRequest.GetRequestStream())
        {
          using (StreamWriter writer = new StreamWriter(requestStream))
          {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
              if (parameter.Value != null)
              {
                if (parameter.Value is IEnumerable<string>)
                {
                  foreach (string str in (IEnumerable<string>) parameter.Value)
                    this.WriteParam(writer, parameter.Key + "[]", str);
                }
                else
                  this.WriteParam(writer, parameter.Key, parameter.Value.ToString());
              }
            }
            if (file != null)
              this.WriteFile(writer, file);
            writer.Write("--{0}--", (object) "notrandomsequencetouseasboundary");
          }
        }
      }
label_40:
      try
      {
        return (HttpWebResponse) httpWebRequest.GetResponse();
      }
      catch (WebException ex)
      {
        HttpWebResponse response = ex.Response as HttpWebResponse;
        if (response != null)
          return response;
        throw;
      }
    }

    public string PrepareUploadParams(IDictionary<string, object> parameters)
    {
      if (parameters == null)
        parameters = (IDictionary<string, object>) new SortedDictionary<string, object>();
      if (!(parameters is SortedDictionary<string, object>))
        parameters = (IDictionary<string, object>) new SortedDictionary<string, object>(parameters);
      string path = "";
      if (parameters.ContainsKey("callback"))
      {
        if (parameters["callback"] != null)
          path = parameters["callback"].ToString();
      }
      try
      {
        parameters["callback"] = (object) this.BuildCallbackUrl(path);
      }
      catch (HttpException ex)
      {
      }
      if (!parameters.ContainsKey("unsigned") || parameters["unsigned"].ToString() == "false")
        this.FinalizeUploadParameters(parameters);
      return JsonConvert.SerializeObject((object) parameters);
    }

    public string GetUploadUrl(string resourceType = "auto")
    {
      return this.ApiUrlV.Action("upload").ResourceType(resourceType).BuildUrl();
    }

    public string BuildCallbackUrl(string path = "")
    {
      if (string.IsNullOrEmpty(path))
        path = "/Content/cloudinary_cors.html";
      if (Regex.IsMatch(path.ToLower(), "^https?:/.*"))
        return path;
      if (HttpContext.Current != null)
        return new Uri(HttpContext.Current.Request.Url, path).ToString();
      throw new HttpException("Http context is not set. Either use this method in the right context or provide an absolute path to file!");
    }

    public IHtmlString BuildUnsignedUploadForm(string field, string preset, IDictionary<string, object> parameters = null, IDictionary<string, string> htmlOptions = null)
    {
      if (parameters == null)
        parameters = (IDictionary<string, object>) new SortedDictionary<string, object>();
      parameters.Add("upload_preset", (object) preset);
      parameters.Add("unsigned", (object) true);
      return this.BuildUploadForm(field, "image", parameters, htmlOptions);
    }

    public IHtmlString BuildUploadForm(string field, string resourceType, IDictionary<string, object> parameters = null, IDictionary<string, string> htmlOptions = null)
    {
      if (htmlOptions == null)
        htmlOptions = (IDictionary<string, string>) new Dictionary<string, string>();
      if (string.IsNullOrEmpty(resourceType))
        resourceType = "auto";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<input type='file' name='file' data-url='").Append(this.GetUploadUrl(resourceType)).Append("' data-form-data='").Append(this.PrepareUploadParams(parameters)).Append("' data-cloudinary-field='").Append(field).Append("' class='cloudinary-fileupload");
      if (htmlOptions.ContainsKey("class"))
        stringBuilder.Append(" ").Append(htmlOptions["class"]);
      foreach (KeyValuePair<string, string> htmlOption in (IEnumerable<KeyValuePair<string, string>>) htmlOptions)
      {
        if (!(htmlOption.Key == "class"))
          stringBuilder.Append("' ").Append(htmlOption.Key).Append("='").Append(HttpUtility.HtmlEncode(htmlOption.Value));
      }
      stringBuilder.Append("'/>");
      return (IHtmlString) new HtmlString(stringBuilder.ToString());
    }

    public string SignParameters(IDictionary<string, object> parameters)
    {
      StringBuilder stringBuilder1 = new StringBuilder(string.Join("&", parameters.Where<KeyValuePair<string, object>>((Func<KeyValuePair<string, object>, bool>) (pair => pair.Value != null)).Select<KeyValuePair<string, object>, string>((Func<KeyValuePair<string, object>, string>) (pair => string.Format("{0}={1}", (object) pair.Key, pair.Value is IEnumerable<string> ? (object) string.Join(",", ((IEnumerable<string>) pair.Value).ToArray<string>()) : (object) pair.Value.ToString()))).ToArray<string>()));
      stringBuilder1.Append(this.Account.ApiSecret);
      byte[] hash = this.ComputeHash(stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (byte num in hash)
        stringBuilder2.Append(num.ToString("x2"));
      return stringBuilder2.ToString();
    }

    public string SignUriPart(string uriPart)
    {
      return "s--" + Convert.ToBase64String(this.ComputeHash(uriPart + this.Account.ApiSecret)).Substring(0, 8).Replace("+", "-").Replace("/", "_") + "--/";
    }

    private byte[] ComputeHash(string s)
    {
      using (SHA1 shA1 = SHA1.Create())
        return shA1.ComputeHash(Encoding.UTF8.GetBytes(s));
    }

    private string GetTime()
    {
      return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
    }

    internal void FinalizeUploadParameters(IDictionary<string, object> parameters)
    {
      parameters.Add("timestamp", (object) this.GetTime());
      parameters.Add("signature", (object) this.SignParameters(parameters));
      parameters.Add("api_key", (object) this.Account.ApiKey);
    }

    private void WriteParam(StreamWriter writer, string key, string value)
    {
      this.WriteLine(writer, "--{0}", (object) "notrandomsequencetouseasboundary");
      this.WriteLine(writer, "Content-Disposition: form-data; name=\"{0}\"", (object) key);
      this.WriteLine(writer);
      this.WriteLine(writer, value);
    }

    private void WriteFile(StreamWriter writer, FileDescription file)
    {
      if (file.IsRemote)
      {
        this.WriteParam(writer, "file", file.FilePath);
      }
      else
      {
        int bytesSent = 0;
        if (file.Stream == null)
        {
          using (FileStream fileStream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
          {
            fileStream.Seek((long) file.BytesSent, SeekOrigin.Begin);
            file.EOF = this.WriteFile(writer, (Stream) fileStream, file.BufferLength, file.FileName, out bytesSent);
            file.BytesSent += bytesSent;
          }
        }
        else
        {
          file.EOF = this.WriteFile(writer, file.Stream, file.BufferLength, file.FileName, out bytesSent);
          file.BytesSent += bytesSent;
        }
      }
    }

    private bool WriteFile(StreamWriter writer, Stream stream, int length, string fileName, out int bytesSent)
    {
      this.WriteLine(writer, "--{0}", (object) "notrandomsequencetouseasboundary");
      this.WriteLine(writer, "Content-Disposition: form-data;  name=\"file\"; filename=\"{0}\"", (object) fileName);
      this.WriteLine(writer, "Content-Type: application/octet-stream");
      this.WriteLine(writer);
      writer.Flush();
      bytesSent = 0;
      byte[] buffer1 = new byte[this.ChunkSize];
      int count1 = 0;
      int num;
      while ((num = length - bytesSent) > 0)
      {
        Stream stream1 = stream;
        byte[] buffer2 = buffer1;
        int offset = 0;
        int count2 = num > buffer1.Length ? buffer1.Length : num;
        if ((count1 = stream1.Read(buffer2, offset, count2)) > 0)
        {
          writer.BaseStream.Write(buffer1, 0, count1);
          bytesSent += count1;
        }
        else
          break;
      }
      return count1 == 0;
    }

    private void WriteLine(StreamWriter writer)
    {
      writer.Write("\r\n");
    }

    private void WriteLine(StreamWriter writer, string format)
    {
      writer.Write(format);
      writer.Write("\r\n");
    }

    private void WriteLine(StreamWriter writer, string format, object val)
    {
      writer.Write(format, val);
      writer.Write("\r\n");
    }
  }
}
