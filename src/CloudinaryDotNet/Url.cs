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
    public class Url //: ICloneable, lets not even go there: http://stackoverflow.com/a/20386650/1275832
    {
        private const string CL_BLANK = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";

        private static readonly string[] DEFAULT_VIDEO_SOURCE_TYPES = new string[3]
        {
            "webm",
            "mp4",
            "ogv"
        };

        private static readonly Regex VIDEO_EXTENSION_RE = new Regex("\\.(" + string.Join("|", DEFAULT_VIDEO_SOURCE_TYPES) + ")$", RegexOptions.Compiled);
        private string m_action = string.Empty;
        private string m_apiVersion;
        private string m_cloudinaryAddr = "res.cloudinary.com";
        private string m_cloudName;
        private string m_cName;
        private List<string> m_customParts = new List<string>();
        private string m_fallbackContent;
        private string m_posterSource;
        private Transformation m_posterTransformation;
        private Url m_posterUrl;
        private string m_privateCdn;
        private string m_resourceType = string.Empty;
        private bool m_secure;
        private bool m_shorten;
        private bool m_signed;
        private readonly ISignProvider m_signProvider;
        private string m_source;
        private Dictionary<string, Transformation> m_sourceTransforms;
        private string[] m_sourceTypes;
        private string m_suffix;
        private Transformation m_transformation;
        private bool m_usePrivateCdn;
        private bool m_useRootPath;
        private bool m_useSubDomain;
        private string m_version;

        public Url(string cloudName)
        {
            m_cloudName = cloudName;
        }

        public Url(string cloudName, ISignProvider signProvider)
            : this(cloudName)
        {
            m_signProvider = signProvider;
        }

        public string FormatValue { get; set; }

        public Transformation Transformation
        {
            get
            {
                if (m_transformation == null)
                    m_transformation = new Transformation();
                return m_transformation;
            }
        }

        public Url Shorten(bool shorten)
        {
            m_shorten = shorten;
            return this;
        }

        public Url CloudinaryAddr(string cloudinaryAddr)
        {
            m_cloudinaryAddr = cloudinaryAddr;
            return this;
        }

        public Url CloudName(string cloudName)
        {
            m_cloudName = cloudName;
            return this;
        }

        public Url Add(string part)
        {
            if (!string.IsNullOrEmpty(part))
                m_customParts.Add(part);
            return this;
        }

        public Url Action(string action)
        {
            m_action = action;
            return this;
        }

        public Url ApiVersion(string apiVersion)
        {
            m_apiVersion = apiVersion;
            return this;
        }

        public Url Version(string version)
        {
            m_version = version;
            return this;
        }

        public Url Source(string source)
        {
            m_source = source;
            return this;
        }

        public Url SourceTypes(params string[] sourceTypes)
        {
            m_sourceTypes = sourceTypes;
            return this;
        }

        public Url Signed(bool signed)
        {
            m_signed = signed;
            return this;
        }

        public Url ResourceType(string resourceType)
        {
            m_resourceType = resourceType;
            return this;
        }

        public Url Format(string format)
        {
            FormatValue = format;
            return this;
        }

        public Url SecureDistribution(string privateCdn)
        {
            m_privateCdn = privateCdn;
            return this;
        }

        public Url CName(string cName)
        {
            m_cName = cName;
            return this;
        }

        public Url Transform(Transformation transformation)
        {
            m_transformation = transformation;
            return this;
        }

        public Url Secure(bool secure = true)
        {
            m_secure = secure;
            return this;
        }

        public Url PrivateCdn(bool usePrivateCdn)
        {
            m_usePrivateCdn = usePrivateCdn;
            return this;
        }

        public Url CSubDomain(bool useSubDomain)
        {
            m_useSubDomain = useSubDomain;
            return this;
        }

        public Url UseRootPath(bool useRootPath)
        {
            m_useRootPath = useRootPath;
            return this;
        }

        public Url FallbackContent(string fallbackContent)
        {
            m_fallbackContent = fallbackContent;
            return this;
        }

        public Url Suffix(string suffix)
        {
            m_suffix = suffix;
            return this;
        }

        public Url SourceTransformationFor(string source, Transformation transform)
        {
            if (m_sourceTransforms == null)
                m_sourceTransforms = new Dictionary<string, Transformation>();
            m_sourceTransforms.Add(source, transform);
            return this;
        }

        public Url PosterTransform(Transformation transformation)
        {
            m_posterTransformation = transformation;
            return this;
        }

        public Url PosterSource(string source)
        {
            m_posterSource = source;
            return this;
        }

        public Url PosterUrl(Url url)
        {
            m_posterUrl = url;
            return this;
        }

        public Url Poster(object poster)
        {
            if (poster is string)
                return PosterSource((string) poster);
            if (poster is Url)
                return PosterUrl((Url) poster);
            if (poster is Transformation)
                return PosterTransform((Transformation) poster);
            if (poster == null || poster is bool && !(bool) poster)
            {
                PosterSource(string.Empty);
                PosterUrl(null);
                PosterTransform(null);
            }
            return this;
        }

        public string BuildSpriteCss(string source)
        {
            m_action = "sprite";
            if (!source.EndsWith(".css"))
                FormatValue = "css";
            return BuildUrl(source);
        }

        public IHtmlContent BuildImageTag(string source, params string[] keyValuePairs)
        {
            return BuildImageTag(source, new StringDictionary(keyValuePairs));
        }

        public IHtmlContent BuildImageTag(string source, StringDictionary dict = null)
        {
            if (dict == null)
                dict = new StringDictionary();
            var str1 = BuildUrl(source);
            if (!string.IsNullOrEmpty(Transformation.HtmlWidth))
                dict.Add("width", Transformation.HtmlWidth);
            if (!string.IsNullOrEmpty(Transformation.HtmlHeight))
                dict.Add("height", Transformation.HtmlHeight);
            if (Transformation.HiDpi || Transformation.IsResponsive)
            {
                var str2 = Transformation.IsResponsive ? "cld-responsive" : "cld-hidpi";
                var str3 = dict["class"];
                dict["class"] = str3 == null ? str2 : str3 + " " + str2;
                dict.Add("data-src", str1);
                var str4 = dict.Remove("responsive_placeholder");
                if (str4 == "blank")
                    str4 = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
                str1 = str4;
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<img");
            if (!string.IsNullOrEmpty(str1))
                stringBuilder.Append(" src=\"").Append(str1).Append("\"");
            foreach (var keyValuePair in dict)
                stringBuilder.Append(" ").Append(keyValuePair.Key).Append("=\"").Append(WebUtility.HtmlEncode(keyValuePair.Value)).Append("\"");
            stringBuilder.Append("/>");
            return new HtmlString(stringBuilder.ToString());
        }

        public IHtmlContent BuildVideoTag(string source, params string[] keyValuePairs)
        {
            return BuildVideoTag(source, new StringDictionary(keyValuePairs));
        }

        public IHtmlContent BuildVideoTag(string source, StringDictionary dict = null)
        {
            if (dict == null)
                dict = new StringDictionary();
            source = VIDEO_EXTENSION_RE.Replace(source, "", 1);
            if (string.IsNullOrEmpty(m_resourceType))
                m_resourceType = "video";
            var strArray = m_sourceTypes ?? DEFAULT_VIDEO_SOURCE_TYPES;
            var str1 = FinalizePosterUrl(source);
            if (!string.IsNullOrEmpty(str1))
                dict.Add("poster", str1);
            var sb = new StringBuilder("<video");
            var flag = strArray.Length > 1;
            if (!flag)
            {
                var str2 = BuildUrl(source + "." + strArray[0]);
                dict.Add("src", str2);
            }
            else
            {
                BuildUrl(source);
            }
            if (dict.ContainsKey("html_height"))
                dict["height"] = dict.Remove("html_height");
            else if (Transformation.HtmlHeight != null)
                dict["height"] = Transformation.HtmlHeight;
            if (dict.ContainsKey("html_width"))
                dict["width"] = dict.Remove("html_width");
            else if (Transformation.HtmlWidth != null)
                dict["width"] = Transformation.HtmlWidth;
            var sort = dict.Sort;
            dict.Sort = true;
            foreach (var keyValuePair in dict)
            {
                sb.Append(" ").Append(keyValuePair.Key);
                if (keyValuePair.Value != null)
                    sb.Append("='").Append(keyValuePair.Value).Append("'");
            }
            dict.Sort = sort;
            sb.Append(">");
            if (flag)
                foreach (var sourceType in strArray)
                    AppendVideoSources(sb, source, sourceType);
            if (!string.IsNullOrEmpty(m_fallbackContent))
                sb.Append(m_fallbackContent);
            sb.Append("</video>");
            return new HtmlString(sb.ToString());
        }

        private void AppendVideoSources(StringBuilder sb, string source, string sourceType)
        {
            var url = Clone();
            if (m_sourceTransforms != null)
            {
                Transformation transformation1 = null;
                if (m_sourceTransforms.TryGetValue(sourceType, out transformation1) && transformation1 != null)
                    if (url.m_transformation == null)
                    {
                        url.Transform(transformation1.Clone());
                    }
                    else
                    {
                        url.m_transformation.Chain();
                        var transformation2 = transformation1.Clone();
                        transformation2.NestedTransforms.AddRange(url.m_transformation.NestedTransforms);
                        url.Transform(transformation2);
                    }
            }
            var str1 = url.Format(sourceType).BuildUrl(source);
            var str2 = sourceType;
            if (sourceType.Equals("ogv", StringComparison.OrdinalIgnoreCase))
                str2 = "ogg";
            var str3 = "video/" + str2;
            sb.Append("<source src='").Append(str1).Append("' type='").Append(str3).Append("'>");
        }

        private string FinalizePosterUrl(string source)
        {
            string str = null;
            if (m_posterUrl != null)
            {
                str = m_posterUrl.BuildUrl();
            }
            else if (m_posterTransformation != null)
            {
                str = Clone().Format("jpg").Transform(m_posterTransformation.Clone()).BuildUrl(source);
            }
            else if (m_posterSource != null)
            {
                if (!string.IsNullOrEmpty(m_posterSource))
                    str = Clone().Format("jpg").BuildUrl(m_posterSource);
            }
            else
            {
                str = Clone().Format("jpg").BuildUrl(source);
            }
            return str;
        }

        public string BuildUrl()
        {
            return BuildUrl(null);
        }

        public string BuildUrl(string source)
        {
            if (string.IsNullOrEmpty(m_cloudName))
                throw new ArgumentException("cloudName must be specified!");
            if (source == null)
                source = m_source;
            if (source == null)
                source = string.Empty;
            if (Regex.IsMatch(source.ToLower(), "^https?:/.*") && (m_action == "upload" || m_action == "asset"))
                return source;
            if (m_action == "fetch" && !string.IsNullOrEmpty(FormatValue))
            {
                Transformation.FetchFormat(FormatValue);
                FormatValue = null;
            }
            var str1 = Transformation.Generate();
            var csource = UpdateSource(source);
            bool sharedDomain;
            var stringList = new List<string>(new string[1]
            {
                GetPrefix(csource.Source, out sharedDomain)
            });
            if (!string.IsNullOrEmpty(m_apiVersion))
            {
                stringList.Add(m_apiVersion);
                stringList.Add(m_cloudName);
            }
            else if (sharedDomain)
            {
                stringList.Add(m_cloudName);
            }
            UpdateAction();
            stringList.Add(m_resourceType);
            stringList.Add(m_action);
            stringList.AddRange(m_customParts);
            if (csource.SourceToSign.Contains("/") && !Regex.IsMatch(csource.SourceToSign, "^v[0-9]+/") && !Regex.IsMatch(csource.SourceToSign, "https?:/.*") && string.IsNullOrEmpty(m_version))
                m_version = "1";
            var str2 = string.IsNullOrEmpty(m_version) ? string.Empty : string.Format("v{0}", m_version);
            if (m_signed)
            {
                if (m_signProvider == null)
                    throw new NullReferenceException("Reference to ISignProvider-compatible object must be provided in order to sign URI!");
                var str3 =
                    m_signProvider.SignUriPart(Regex.Replace(Regex.Replace(Regex.Replace(string.Join("/", str1, csource.SourceToSign), "^/+", string.Empty), "([^:])/{2,}", "$1/"), "/$", string.Empty));
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
                csource1 = new CSource(Encode(source));
            }
            else
            {
                csource1 = new CSource(Encode(Decode(source)));
                if (!string.IsNullOrEmpty(m_suffix))
                {
                    if (Regex.IsMatch(m_suffix, "[\\./]"))
                        throw new ArgumentException("Suffix should not include . or /!");
                    var csource2 = csource1;
                    var str = csource2.Source + "/" + m_suffix;
                    csource2.Source = str;
                }
                if (!string.IsNullOrEmpty(FormatValue))
                    csource1 += "." + FormatValue;
            }
            return csource1;
        }

        private string GetPrefix(string source, out bool sharedDomain)
        {
            sharedDomain = !m_usePrivateCdn;
            var str1 = m_privateCdn;
            string str2;
            if (m_secure)
            {
                if (string.IsNullOrEmpty(str1) || "cloudinary-a.akamaihd.net" == str1)
                    str1 = m_usePrivateCdn ? m_cloudName + "-res.cloudinary.com" : "res.cloudinary.com";
                sharedDomain |= str1 == "res.cloudinary.com";
                if (sharedDomain && m_useSubDomain)
                    str1 = str1.Replace("res.cloudinary.com", "res-" + Shard(source) + ".cloudinary.com");
                str2 = string.Format("https://{0}", str1);
            }
            else if (Regex.IsMatch(m_cloudinaryAddr.ToLower(), "^https?:/.*"))
            {
                str2 = m_cloudinaryAddr;
            }
            else if (m_cName != null)
            {
                str2 = "http://" + (m_useSubDomain ? "a" + Shard(source) + "." : string.Empty) + m_cName;
            }
            else
            {
                var str3 = m_useSubDomain ? "-" + Shard(source) : string.Empty;
                str2 = "http://" + (m_usePrivateCdn ? m_cloudName + "-" : string.Empty) + "res" + str3 + ".cloudinary.com";
            }
            return str2;
        }

        private void UpdateAction()
        {
            if (!string.IsNullOrEmpty(m_suffix))
                if (m_resourceType == "image" && m_action == "upload")
                {
                    m_resourceType = "images";
                    m_action = null;
                }
                else
                {
                    if (!(m_resourceType == "raw") || !(m_action == "upload"))
                        throw new NotSupportedException("URL Suffix only supported for image/upload and raw/upload!");
                    m_resourceType = "files";
                    m_action = null;
                }
            if (m_useRootPath)
            {
                if ((!(m_resourceType == "image") || !(m_action == "upload")) && (!(m_resourceType == "images") || !string.IsNullOrEmpty(m_action)))
                    throw new NotSupportedException("Root path only supported for image/upload!");
                m_resourceType = string.Empty;
                m_action = string.Empty;
            }
            if (!m_shorten || !(m_resourceType == "image") || !(m_action == "upload"))
                return;
            m_resourceType = string.Empty;
            m_action = "iu";
        }

        private static string Shard(string input)
        {
            return ((Crc32.ComputeChecksum(Encoding.UTF8.GetBytes(input)) % 5U + 5U) % 5U + 1U).ToString();
        }

        private static string Decode(string input)
        {
            var stringBuilder = new StringBuilder(input.Length);
            var startIndex = 0;
            while (startIndex < input.Length)
            {
                var num = input.IndexOf('%', startIndex);
                if (num == -1)
                {
                    stringBuilder.Append(input.Substring(startIndex));
                    startIndex = input.Length;
                }
                else
                {
                    stringBuilder.Append(input.Substring(startIndex, num - startIndex));
                    var ch = (char) short.Parse(input.Substring(num + 1, 2), NumberStyles.HexNumber);
                    stringBuilder.Append(ch);
                    startIndex = num + 3;
                }
            }
            return stringBuilder.ToString();
        }

        private static string Encode(string input)
        {
            var stringBuilder = new StringBuilder(input.Length);
            foreach (var ch in input)
                if (!IsSafe(ch))
                {
                    stringBuilder.Append('%');
                    stringBuilder.Append(string.Format("{0:X2}", (short) ch));
                }
                else
                {
                    stringBuilder.Append(ch);
                }
            return stringBuilder.ToString();
        }

        private static bool IsSafe(char ch)
        {
            if (ch >= 48 && ch <= 57 || ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)
                return true;
            return "/:-_.*".IndexOf(ch) >= 0;
        }

        public Url Clone()
        {
            var url = (Url) MemberwiseClone();
            if (m_transformation != null)
                url.m_transformation = m_transformation.Clone();
            if (m_posterTransformation != null)
                url.m_posterTransformation = m_posterTransformation.Clone();
            if (m_posterUrl != null)
                url.m_posterUrl = m_posterUrl.Clone();
            if (m_sourceTypes != null)
            {
                url.m_sourceTypes = new string[m_sourceTypes.Length];
                Array.Copy(m_sourceTypes, url.m_sourceTypes, m_sourceTypes.Length);
            }
            if (m_sourceTransforms != null)
            {
                url.m_sourceTransforms = new Dictionary<string, Transformation>();
                foreach (var sourceTransform in m_sourceTransforms)
                    url.m_sourceTransforms.Add(sourceTransform.Key, sourceTransform.Value.Clone());
            }
            url.m_customParts = new List<string>(m_customParts);
            return url;
        }

        //}
        //  return (object) this.Clone();
        //{

        //object ICloneable.Clone()
    }
}