using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;

namespace CloudinaryDotNet
{
    public static class HtmlUrlExtensions
    {

        public static IHtmlContent BuildImageTag(this Url url, string source, params string[] keyValuePairs)
        {
            return url.BuildImageTag(source, keyValuePairs.KeyValueToDictionary());
        }

        public static IHtmlContent BuildImageTag(this Url url, string source, IDictionary<string, string> options = null)
        {
            if (options == null)
                options = new Dictionary<string, string>();
            var str1 = url.BuildUrl(source);
            if (!string.IsNullOrEmpty(url.Transformation.HtmlWidth))
                options.Add("width", url.Transformation.HtmlWidth);
            if (!string.IsNullOrEmpty(url.Transformation.HtmlHeight))
                options.Add("height", url.Transformation.HtmlHeight);

            string placeholder = null;
            if (url.Transformation.HiDpi || url.Transformation.IsResponsive)
            {
                var isResponsive = url.Transformation.IsResponsive ? "cld-responsive" : "cld-hidpi";
                var className = options["class"];
                options["class"] = className == null ? isResponsive : className + " " + isResponsive;
                options.Add("data-src", str1);
                if(options.TryGetValue("responsive_placeholder", out placeholder))
                    if (placeholder == "blank")
                        placeholder = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<img");
            if (!string.IsNullOrEmpty(placeholder))
                stringBuilder.Append(" src=\"").Append(placeholder).Append("\"");
            foreach (var keyValuePair in options)
                stringBuilder.Append(" ").Append(keyValuePair.Key).Append("=\"").Append(WebUtility.HtmlEncode(keyValuePair.Value)).Append("\"");
            stringBuilder.Append("/>");
            return new HtmlString(stringBuilder.ToString());
        }

        public static IHtmlContent BuildVideoTag(this Url url, string source, params string[] keyValuePairs)
        {
            return url.BuildVideoTag(source, keyValuePairs.KeyValueToDictionary());
        }


        private static readonly string[] DEFAULT_VIDEO_SOURCE_TYPES = new string[3]
        {
            "webm",
            "mp4",
            "ogv"
        };
        public static readonly Regex VIDEO_EXTENSION_RE = new Regex("\\.(" + string.Join("|", DEFAULT_VIDEO_SOURCE_TYPES) + ")$", RegexOptions.Compiled);

        public static IHtmlContent BuildVideoTag(this Url url, string source, IDictionary<string, string> options = null)
        {
            if (options == null)
                options = new Dictionary<string, string>();
            source = VIDEO_EXTENSION_RE.Replace(source, "", 1);
            if (string.IsNullOrEmpty(url.m_resourceType))
                url.m_resourceType = "video";
            var strArray = url.m_sourceTypes ?? DEFAULT_VIDEO_SOURCE_TYPES;
            var str1 = FinalizePosterUrl(url, source);
            if (!string.IsNullOrEmpty(str1))
                options.Add("poster", str1);
            var sb = new StringBuilder("<video");
            var flag = strArray.Length > 1;
            if (!flag)
            {
                var str2 = url.BuildUrl(source + "." + strArray[0]);
                options.Add("src", str2);
            }
            else
            {
                url.BuildUrl(source);
            }
            if (options.ContainsKey("html_height"))
                options["height"] = options.SliceValue("html_height");
            else if (url.Transformation.HtmlHeight != null)
                options["height"] = url.Transformation.HtmlHeight;
            if (options.ContainsKey("html_width"))
                options["width"] = options.SliceValue("html_width");
            else if (url.Transformation.HtmlWidth != null)
                options["width"] = url.Transformation.HtmlWidth;
            foreach (var keyValuePair in options.OrderBy(x=> x.Key))
            {
                sb.Append(" ").Append(keyValuePair.Key);
                if (keyValuePair.Value != null)
                    sb.Append("='").Append(keyValuePair.Value).Append("'");
            }
            sb.Append(">");
            if (flag)
                foreach (var sourceType in strArray)
                    url.AppendVideoSources(sb, source, sourceType);
            if (!string.IsNullOrEmpty(url.m_fallbackContent))
                sb.Append(url.m_fallbackContent);
            sb.Append("</video>");
            return new HtmlString(sb.ToString());
        }


        private static void AppendVideoSources(this Url url2, StringBuilder sb, string source, string sourceType)
        {
            var url = url2.Clone();
            if (url2.m_sourceTransforms != null)
            {
                Transformation transformation1;
                if (url2.m_sourceTransforms.TryGetValue(sourceType, out transformation1) && transformation1 != null)
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

        private static string FinalizePosterUrl(this Url url, string source)
        {
            if (url.m_posterUrl != null)
            {
                return url.m_posterUrl.BuildUrl();
            }
            if (url.m_posterTransformation != null)
            {
                return url.Clone().Format("jpg").Transform(url.m_posterTransformation.Clone()).BuildUrl(source);
            }
            if (url.m_posterSource != null)
            {
                    return url.Clone().Format("jpg").BuildUrl(url.m_posterSource);
            }
            return url.Clone().Format("jpg").BuildUrl(source);
        }

        private static IDictionary<string, string> KeyValueToDictionary(this IEnumerable<string> keyValues)
        {
            return keyValues.Select(x =>
            {
                var parts = x.Split('=');
                return new KeyValuePair<string, string>(parts[0],
                    parts.Length > 1 ? string.Join("=", parts.Skip(1)) : null);
            }).ToDictionary(x=> x.Key,x=> x.Value);
        }


    }
}