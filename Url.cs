// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Url
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;

namespace CloudinaryDotNet
{
  public class Url  //: ICloneable, lets not even go there: http://stackoverflow.com/a/20386650/1275832
    {
    private static readonly string[] DEFAULT_VIDEO_SOURCE_TYPES = new string[3]
    {
      "webm",
      "mp4",
      "ogv"
    };
    private static readonly Regex VIDEO_EXTENSION_RE = new Regex("\\.(" + string.Join("|", Url.DEFAULT_VIDEO_SOURCE_TYPES) + ")$", RegexOptions.Compiled);
    private string m_cloudinaryAddr = "res.cloudinary.com";
    private List<string> m_customParts = new List<string>();
    private string m_action = string.Empty;
    private string m_resourceType = string.Empty;
    private const string CL_BLANK = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
    private ISignProvider m_signProvider;
    private string m_cloudName;
    private string m_apiVersion;
    private bool m_shorten;
    private bool m_secure;
    private bool m_usePrivateCdn;
    private bool m_signed;
    private bool m_useRootPath;
    private string m_suffix;
    private string m_privateCdn;
    private string m_version;
    private string m_cName;
    private string m_source;
    private string m_fallbackContent;
    private bool m_useSubDomain;
    private Dictionary<string, Transformation> m_sourceTransforms;
    private Transformation m_posterTransformation;
    private string m_posterSource;
    private Url m_posterUrl;
    private string[] m_sourceTypes;
    private Transformation m_transformation;

    public string FormatValue { get; set; }

    public Transformation Transformation
    {
      get
      {
        if (this.m_transformation == null)
          this.m_transformation = new Transformation();
        return this.m_transformation;
      }
    }

    public Url(string cloudName)
    {
      this.m_cloudName = cloudName;
    }

    public Url(string cloudName, ISignProvider signProvider)
      : this(cloudName)
    {
      this.m_signProvider = signProvider;
    }

    public Url Shorten(bool shorten)
    {
      this.m_shorten = shorten;
      return this;
    }

    public Url CloudinaryAddr(string cloudinaryAddr)
    {
      this.m_cloudinaryAddr = cloudinaryAddr;
      return this;
    }

    public Url CloudName(string cloudName)
    {
      this.m_cloudName = cloudName;
      return this;
    }

    public Url Add(string part)
    {
      if (!string.IsNullOrEmpty(part))
        this.m_customParts.Add(part);
      return this;
    }

    public Url Action(string action)
    {
      this.m_action = action;
      return this;
    }

    public Url ApiVersion(string apiVersion)
    {
      this.m_apiVersion = apiVersion;
      return this;
    }

    public Url Version(string version)
    {
      this.m_version = version;
      return this;
    }

    public Url Source(string source)
    {
      this.m_source = source;
      return this;
    }

    public Url SourceTypes(params string[] sourceTypes)
    {
      this.m_sourceTypes = sourceTypes;
      return this;
    }

    public Url Signed(bool signed)
    {
      this.m_signed = signed;
      return this;
    }

    public Url ResourceType(string resourceType)
    {
      this.m_resourceType = resourceType;
      return this;
    }

    public Url Format(string format)
    {
      this.FormatValue = format;
      return this;
    }

    public Url SecureDistribution(string privateCdn)
    {
      this.m_privateCdn = privateCdn;
      return this;
    }

    public Url CName(string cName)
    {
      this.m_cName = cName;
      return this;
    }

    public Url Transform(Transformation transformation)
    {
      this.m_transformation = transformation;
      return this;
    }

    public Url Secure(bool secure = true)
    {
      this.m_secure = secure;
      return this;
    }

    public Url PrivateCdn(bool usePrivateCdn)
    {
      this.m_usePrivateCdn = usePrivateCdn;
      return this;
    }

    public Url CSubDomain(bool useSubDomain)
    {
      this.m_useSubDomain = useSubDomain;
      return this;
    }

    public Url UseRootPath(bool useRootPath)
    {
      this.m_useRootPath = useRootPath;
      return this;
    }

    public Url FallbackContent(string fallbackContent)
    {
      this.m_fallbackContent = fallbackContent;
      return this;
    }

    public Url Suffix(string suffix)
    {
      this.m_suffix = suffix;
      return this;
    }

    public Url SourceTransformationFor(string source, Transformation transform)
    {
      if (this.m_sourceTransforms == null)
        this.m_sourceTransforms = new Dictionary<string, Transformation>();
      this.m_sourceTransforms.Add(source, transform);
      return this;
    }

    public Url PosterTransform(Transformation transformation)
    {
      this.m_posterTransformation = transformation;
      return this;
    }

    public Url PosterSource(string source)
    {
      this.m_posterSource = source;
      return this;
    }

    public Url PosterUrl(Url url)
    {
      this.m_posterUrl = url;
      return this;
    }

    public Url Poster(object poster)
    {
      if (poster is string)
        return this.PosterSource((string) poster);
      if (poster is Url)
        return this.PosterUrl((Url) poster);
      if (poster is Transformation)
        return this.PosterTransform((Transformation) poster);
      if (poster == null || poster is bool && !(bool) poster)
      {
        this.PosterSource(string.Empty);
        this.PosterUrl((Url) null);
        this.PosterTransform((Transformation) null);
      }
      return this;
    }

    public string BuildSpriteCss(string source)
    {
      this.m_action = "sprite";
      if (!source.EndsWith(".css"))
        this.FormatValue = "css";
      return this.BuildUrl(source);
    }

    public IHtmlContent BuildImageTag(string source, params string[] keyValuePairs)
    {
      return this.BuildImageTag(source, new StringDictionary(keyValuePairs));
    }

    public IHtmlContent BuildImageTag(string source, StringDictionary dict = null)
    {
      if (dict == null)
        dict = new StringDictionary();
      string str1 = this.BuildUrl(source);
      if (!string.IsNullOrEmpty(this.Transformation.HtmlWidth))
        dict.Add("width", this.Transformation.HtmlWidth);
      if (!string.IsNullOrEmpty(this.Transformation.HtmlHeight))
        dict.Add("height", this.Transformation.HtmlHeight);
      if (this.Transformation.HiDpi || this.Transformation.IsResponsive)
      {
        string str2 = this.Transformation.IsResponsive ? "cld-responsive" : "cld-hidpi";
        string str3 = dict["class"];
        dict["class"] = str3 == null ? str2 : str3 + " " + str2;
        dict.Add("data-src", str1);
        string str4 = dict.Remove("responsive_placeholder");
        if (str4 == "blank")
          str4 = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
        str1 = str4;
      }
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<img");
      if (!string.IsNullOrEmpty(str1))
        stringBuilder.Append(" src=\"").Append(str1).Append("\"");
      foreach (KeyValuePair<string, string> keyValuePair in dict)
        stringBuilder.Append(" ").Append(keyValuePair.Key).Append("=\"").Append(WebUtility.HtmlEncode(keyValuePair.Value)).Append("\"");
      stringBuilder.Append("/>");
      return (IHtmlContent) new HtmlString(stringBuilder.ToString());
    }

    public IHtmlContent BuildVideoTag(string source, params string[] keyValuePairs)
    {
      return this.BuildVideoTag(source, new StringDictionary(keyValuePairs));
    }

    public IHtmlContent BuildVideoTag(string source, StringDictionary dict = null)
    {
      if (dict == null)
        dict = new StringDictionary();
      source = Url.VIDEO_EXTENSION_RE.Replace(source, "", 1);
      if (string.IsNullOrEmpty(this.m_resourceType))
        this.m_resourceType = "video";
      string[] strArray = this.m_sourceTypes ?? Url.DEFAULT_VIDEO_SOURCE_TYPES;
      string str1 = this.FinalizePosterUrl(source);
      if (!string.IsNullOrEmpty(str1))
        dict.Add("poster", str1);
      StringBuilder sb = new StringBuilder("<video");
      bool flag = strArray.Length > 1;
      if (!flag)
      {
        string str2 = this.BuildUrl(source + "." + strArray[0]);
        dict.Add("src", str2);
      }
      else
        this.BuildUrl(source);
      if (dict.ContainsKey("html_height"))
        dict["height"] = dict.Remove("html_height");
      else if (this.Transformation.HtmlHeight != null)
        dict["height"] = this.Transformation.HtmlHeight;
      if (dict.ContainsKey("html_width"))
        dict["width"] = dict.Remove("html_width");
      else if (this.Transformation.HtmlWidth != null)
        dict["width"] = this.Transformation.HtmlWidth;
      bool sort = dict.Sort;
      dict.Sort = true;
      foreach (KeyValuePair<string, string> keyValuePair in dict)
      {
        sb.Append(" ").Append(keyValuePair.Key);
        if (keyValuePair.Value != null)
          sb.Append("='").Append(keyValuePair.Value).Append("'");
      }
      dict.Sort = sort;
      sb.Append(">");
      if (flag)
      {
        foreach (string sourceType in strArray)
          this.AppendVideoSources(sb, source, sourceType);
      }
      if (!string.IsNullOrEmpty(this.m_fallbackContent))
        sb.Append(this.m_fallbackContent);
      sb.Append("</video>");
      return (IHtmlContent) new HtmlString(sb.ToString());
    }

    private void AppendVideoSources(StringBuilder sb, string source, string sourceType)
    {
      Url url = this.Clone();
      if (this.m_sourceTransforms != null)
      {
        Transformation transformation1 = (Transformation) null;
        if (this.m_sourceTransforms.TryGetValue(sourceType, out transformation1) && transformation1 != null)
        {
          if (url.m_transformation == null)
          {
            url.Transform(transformation1.Clone());
          }
          else
          {
            url.m_transformation.Chain();
            Transformation transformation2 = transformation1.Clone();
            transformation2.NestedTransforms.AddRange((IEnumerable<Transformation>) url.m_transformation.NestedTransforms);
            url.Transform(transformation2);
          }
        }
      }
      string str1 = url.Format(sourceType).BuildUrl(source);
      string str2 = sourceType;
      if (sourceType.Equals("ogv", StringComparison.OrdinalIgnoreCase))
        str2 = "ogg";
      string str3 = "video/" + str2;
      sb.Append("<source src='").Append(str1).Append("' type='").Append(str3).Append("'>");
    }

    private string FinalizePosterUrl(string source)
    {
      string str = (string) null;
      if (this.m_posterUrl != null)
        str = this.m_posterUrl.BuildUrl();
      else if (this.m_posterTransformation != null)
        str = this.Clone().Format("jpg").Transform(this.m_posterTransformation.Clone()).BuildUrl(source);
      else if (this.m_posterSource != null)
      {
        if (!string.IsNullOrEmpty(this.m_posterSource))
          str = this.Clone().Format("jpg").BuildUrl(this.m_posterSource);
      }
      else
        str = this.Clone().Format("jpg").BuildUrl(source);
      return str;
    }

    public string BuildUrl()
    {
      return this.BuildUrl((string) null);
    }

    public string BuildUrl(string source)
    {
      if (string.IsNullOrEmpty(this.m_cloudName))
        throw new ArgumentException("cloudName must be specified!");
      if (source == null)
        source = this.m_source;
      if (source == null)
        source = string.Empty;
      if (Regex.IsMatch(source.ToLower(), "^https?:/.*") && (this.m_action == "upload" || this.m_action == "asset"))
        return source;
      if (this.m_action == "fetch" && !string.IsNullOrEmpty(this.FormatValue))
      {
        this.Transformation.FetchFormat(this.FormatValue);
        this.FormatValue = (string) null;
      }
      string str1 = this.Transformation.Generate();
      CSource csource = this.UpdateSource(source);
      bool sharedDomain;
      List<string> stringList = new List<string>((IEnumerable<string>) new string[1]
      {
        this.GetPrefix(csource.Source, out sharedDomain)
      });
      if (!string.IsNullOrEmpty(this.m_apiVersion))
      {
        stringList.Add(this.m_apiVersion);
        stringList.Add(this.m_cloudName);
      }
      else if (sharedDomain)
        stringList.Add(this.m_cloudName);
      this.UpdateAction();
      stringList.Add(this.m_resourceType);
      stringList.Add(this.m_action);
      stringList.AddRange((IEnumerable<string>) this.m_customParts);
      if (csource.SourceToSign.Contains("/") && !Regex.IsMatch(csource.SourceToSign, "^v[0-9]+/") && (!Regex.IsMatch(csource.SourceToSign, "https?:/.*") && string.IsNullOrEmpty(this.m_version)))
        this.m_version = "1";
      string str2 = string.IsNullOrEmpty(this.m_version) ? string.Empty : string.Format("v{0}", (object) this.m_version);
      if (this.m_signed)
      {
        if (this.m_signProvider == null)
          throw new NullReferenceException("Reference to ISignProvider-compatible object must be provided in order to sign URI!");
        string str3 = this.m_signProvider.SignUriPart(Regex.Replace(Regex.Replace(Regex.Replace(string.Join("/", str1, csource.SourceToSign), "^/+", string.Empty), "([^:])/{2,}", "$1/"), "/$", string.Empty));
        stringList.Add(str3);
      }
      stringList.Add(str1);
      stringList.Add(str2);
      stringList.Add(csource.Source);
      return Regex.Replace(Regex.Replace(string.Join("/", stringList.ToArray()), "([^:])/{2,}", "$1/"), "/$", string.Empty);
    }

    private CSource UpdateSource(string source)
    {
      CSource csource1;
      if (Regex.IsMatch(source.ToLower(), "^https?:/.*"))
      {
        csource1 = new CSource(Url.Encode(source));
      }
      else
      {
        csource1 = new CSource(Url.Encode(Url.Decode(source)));
        if (!string.IsNullOrEmpty(this.m_suffix))
        {
          if (Regex.IsMatch(this.m_suffix, "[\\./]"))
            throw new ArgumentException("Suffix should not include . or /!");
          CSource csource2 = csource1;
          string str = csource2.Source + "/" + this.m_suffix;
          csource2.Source = str;
        }
        if (!string.IsNullOrEmpty(this.FormatValue))
          csource1 += "." + this.FormatValue;
      }
      return csource1;
    }

    private string GetPrefix(string source, out bool sharedDomain)
    {
      sharedDomain = !this.m_usePrivateCdn;
      string str1 = this.m_privateCdn;
      string str2;
      if (this.m_secure)
      {
        if (string.IsNullOrEmpty(str1) || "cloudinary-a.akamaihd.net" == str1)
          str1 = this.m_usePrivateCdn ? this.m_cloudName + "-res.cloudinary.com" : "res.cloudinary.com";
        sharedDomain |= str1 == "res.cloudinary.com";
        if (sharedDomain && this.m_useSubDomain)
          str1 = str1.Replace("res.cloudinary.com", "res-" + Url.Shard(source) + ".cloudinary.com");
        str2 = string.Format("https://{0}", (object) str1);
      }
      else if (Regex.IsMatch(this.m_cloudinaryAddr.ToLower(), "^https?:/.*"))
        str2 = this.m_cloudinaryAddr;
      else if (this.m_cName != null)
      {
        str2 = "http://" + (this.m_useSubDomain ? "a" + Url.Shard(source) + "." : string.Empty) + this.m_cName;
      }
      else
      {
        string str3 = this.m_useSubDomain ? "-" + Url.Shard(source) : string.Empty;
        str2 = "http://" + ((this.m_usePrivateCdn ? this.m_cloudName + "-" : string.Empty) + "res" + str3 + ".cloudinary.com");
      }
      return str2;
    }

    private void UpdateAction()
    {
      if (!string.IsNullOrEmpty(this.m_suffix))
      {
        if (this.m_resourceType == "image" && this.m_action == "upload")
        {
          this.m_resourceType = "images";
          this.m_action = (string) null;
        }
        else
        {
          if (!(this.m_resourceType == "raw") || !(this.m_action == "upload"))
            throw new NotSupportedException("URL Suffix only supported for image/upload and raw/upload!");
          this.m_resourceType = "files";
          this.m_action = (string) null;
        }
      }
      if (this.m_useRootPath)
      {
        if ((!(this.m_resourceType == "image") || !(this.m_action == "upload")) && (!(this.m_resourceType == "images") || !string.IsNullOrEmpty(this.m_action)))
          throw new NotSupportedException("Root path only supported for image/upload!");
        this.m_resourceType = string.Empty;
        this.m_action = string.Empty;
      }
      if (!this.m_shorten || !(this.m_resourceType == "image") || !(this.m_action == "upload"))
        return;
      this.m_resourceType = string.Empty;
      this.m_action = "iu";
    }

    private static string Shard(string input)
    {
      return ((Crc32.ComputeChecksum(Encoding.UTF8.GetBytes(input)) % 5U + 5U) % 5U + 1U).ToString();
    }

    private static string Decode(string input)
    {
      StringBuilder stringBuilder = new StringBuilder(input.Length);
      int startIndex = 0;
      while (startIndex < input.Length)
      {
        int num = input.IndexOf('%', startIndex);
        if (num == -1)
        {
          stringBuilder.Append(input.Substring(startIndex));
          startIndex = input.Length;
        }
        else
        {
          stringBuilder.Append(input.Substring(startIndex, num - startIndex));
          char ch = (char) short.Parse(input.Substring(num + 1, 2), NumberStyles.HexNumber);
          stringBuilder.Append(ch);
          startIndex = num + 3;
        }
      }
      return stringBuilder.ToString();
    }

    private static string Encode(string input)
    {
      StringBuilder stringBuilder = new StringBuilder(input.Length);
      foreach (char ch in input)
      {
        if (!Url.IsSafe(ch))
        {
          stringBuilder.Append('%');
          stringBuilder.Append(string.Format("{0:X2}", (object) (short) ch));
        }
        else
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    private static bool IsSafe(char ch)
    {
      if ((int) ch >= 48 && (int) ch <= 57 || (int) ch >= 65 && (int) ch <= 90 || (int) ch >= 97 && (int) ch <= 122)
        return true;
      return "/:-_.*".IndexOf(ch) >= 0;
    }

    public Url Clone()
    {
      Url url = (Url) this.MemberwiseClone();
      if (this.m_transformation != null)
        url.m_transformation = this.m_transformation.Clone();
      if (this.m_posterTransformation != null)
        url.m_posterTransformation = this.m_posterTransformation.Clone();
      if (this.m_posterUrl != null)
        url.m_posterUrl = this.m_posterUrl.Clone();
      if (this.m_sourceTypes != null)
      {
        url.m_sourceTypes = new string[this.m_sourceTypes.Length];
        Array.Copy((Array) this.m_sourceTypes, (Array) url.m_sourceTypes, this.m_sourceTypes.Length);
      }
      if (this.m_sourceTransforms != null)
      {
        url.m_sourceTransforms = new Dictionary<string, Transformation>();
        foreach (KeyValuePair<string, Transformation> sourceTransform in this.m_sourceTransforms)
          url.m_sourceTransforms.Add(sourceTransform.Key, sourceTransform.Value.Clone());
      }
      url.m_customParts = new List<string>((IEnumerable<string>) this.m_customParts);
      return url;
    }

    //object ICloneable.Clone()
    //{
    //  return (object) this.Clone();
    //}
  }
}
