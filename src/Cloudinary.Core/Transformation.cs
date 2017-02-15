// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Transformation
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CloudinaryDotNet
{
    public class Transformation //: ICloneable, lets not even go there: http://stackoverflow.com/a/20386650/1275832
    {
        private static readonly Regex RANGE_VALUE_RE = new Regex("^((?:\\d+\\.)?\\d+)([%pP])?$", RegexOptions.Compiled);
        private static readonly Regex RANGE_RE = new Regex("^(\\d+\\.)?\\d+[%pP]?\\.\\.(\\d+\\.)?\\d+[%pP]?$", RegexOptions.Compiled);

        private static readonly string[] SimpleParams = new string[46]
        {
            "x", "x", "y", "y", "r", "radius", "d", "default_image", "g", "gravity", "cs", "color_space", "p", "prefix", "l", "overlay", "u", "underlay", "f", "fetch_format", "dn", "density", "pg",
            "page", "dl", "delay", "e", "effect", "bo", "border", "q", "quality", "o", "opacity", "z", "zoom", "ac", "audio_codec", "br", "bit_rate", "af", "audio_frequency", "ar", "aspect_ratio",
            "vs", "video_sampling"
        };

        private static readonly Transformation DEFAULT_RESPONSIVE_WIDTH_TRANSFORM = new Transformation().Width("auto").Crop("limit");
        private static Transformation m_responsiveWidthTransform;
        protected string m_htmlHeight;
        protected string m_htmlWidth;
        protected List<Transformation> m_nestedTransforms = new List<Transformation>();
        protected Dictionary<string, object> m_transformParams = new Dictionary<string, object>();

        public Transformation()
        {
        }

        public Transformation(List<Transformation> transforms)
        {
            if (transforms == null)
                return;
            m_nestedTransforms = transforms;
        }

        public Transformation(params string[] transformParams)
        {
            foreach (var transformParam in transformParams)
            {
                var strArray = transformParam.Split('=');
                if (strArray.Length != 2)
                    throw new ArgumentException(string.Format("Couldn't parse '{0}'!", transformParam));
                Add(strArray[0], strArray[1]);
            }
        }

        public Transformation(Dictionary<string, object> transformParams)
        {
            foreach (var key in transformParams.Keys)
                m_transformParams.Add(key, transformParams[key]);
        }

        public Transformation(Dictionary<string, object>[] dictionary)
        {
            for (var index = 0; index < dictionary.Length; ++index)
                if (index == dictionary.Length - 1)
                    m_transformParams = dictionary[index];
                else
                    m_nestedTransforms.Add(new Transformation(dictionary[index]));
        }

        public static object DefaultDpr { get; set; }

        public static bool DefaultIsResponsive { get; set; }

        public static Transformation ResponsiveWidthTransform
        {
            get
            {
                if (m_responsiveWidthTransform == null)
                    return DEFAULT_RESPONSIVE_WIDTH_TRANSFORM;
                return m_responsiveWidthTransform;
            }
            set { m_responsiveWidthTransform = value; }
        }

        public Dictionary<string, object> Params
        {
            get { return m_transformParams; }
        }

        public List<Transformation> NestedTransforms
        {
            get { return m_nestedTransforms; }
        }

        public bool HiDpi { get; private set; }

        public bool IsResponsive { get; private set; }

        public string HtmlWidth
        {
            get { return m_htmlWidth; }
        }

        public string HtmlHeight
        {
            get { return m_htmlHeight; }
        }

        public Transformation Width(object value)
        {
            return Add("width", value);
        }

        public Transformation Height(object value)
        {
            return Add("height", value);
        }

        public Transformation SetHtmlWidth(object value)
        {
            m_htmlWidth = value.ToString();
            return this;
        }

        public Transformation SetHtmlHeight(object value)
        {
            m_htmlHeight = value.ToString();
            return this;
        }

        public Transformation Named(params string[] value)
        {
            return Add("transformation", value);
        }

        public Transformation AspectRatio(double value)
        {
            return AspectRatio(value.ToString(CultureInfo.InvariantCulture));
        }

        public Transformation AspectRatio(int nom, int denom)
        {
            return AspectRatio(string.Format("{0}:{1}", nom, denom));
        }

        public Transformation AspectRatio(string value)
        {
            return Add("aspect_ratio", value);
        }

        public Transformation Crop(string value)
        {
            return Add("crop", value);
        }

        public Transformation Background(string value)
        {
            return Add("background", Regex.Replace(value, "^#", "rgb:"));
        }

        public Transformation Color(string value)
        {
            return Add("color", Regex.Replace(value, "^#", "rgb:"));
        }

        public Transformation Effect(string value)
        {
            return Add("effect", value);
        }

        public Transformation Effect(string effect, object param)
        {
            return Add("effect", effect + ":" + param);
        }

        public Transformation Angle(int value)
        {
            return Add("angle", value);
        }

        public Transformation Angle(params string[] value)
        {
            return Add("angle", value);
        }

        public Transformation Border(string value)
        {
            return Add("border", value);
        }

        public Transformation Border(int width, string color)
        {
            return Add("border", width + "px_solid_" + Regex.Replace(color, "^#", "rgb:"));
        }

        public Transformation X(object value)
        {
            return Add("x", value);
        }

        public Transformation Y(object value)
        {
            return Add("y", value);
        }

        public Transformation Radius(object value)
        {
            return Add("radius", value);
        }

        public Transformation Quality(object value)
        {
            return Add("quality", value);
        }

        public Transformation DefaultImage(string value)
        {
            return Add("default_image", value);
        }

        public Transformation Gravity(string value)
        {
            return Add("gravity", value);
        }

        public Transformation ColorSpace(string value)
        {
            return Add("color_space", value);
        }

        public Transformation Prefix(string value)
        {
            return Add("prefix", value);
        }

        public Transformation Opacity(int value)
        {
            return Add("opacity", value);
        }

        public Transformation Overlay(string value)
        {
            return Add("overlay", value);
        }

        public Transformation Overlay(BaseLayer value)
        {
            return Add("overlay", value);
        }

        public Transformation Underlay(string value)
        {
            return Add("underlay", value);
        }

        public Transformation Underlay(BaseLayer value)
        {
            return Add("underlay", value);
        }

        public Transformation FetchFormat(string value)
        {
            return Add("fetch_format", value);
        }

        public Transformation Density(object value)
        {
            return Add("density", value);
        }

        public Transformation Page(object value)
        {
            return Add("page", value);
        }

        public Transformation Delay(object value)
        {
            return Add("delay", value);
        }

        public Transformation RawTransformation(string value)
        {
            return Add("raw_transformation", value);
        }

        public Transformation Flags(params string[] value)
        {
            return Add("flags", value);
        }

        public Transformation Zoom(int value)
        {
            return Add("zoom", value);
        }

        public Transformation Zoom(string value)
        {
            return Add("zoom", value);
        }

        public Transformation Zoom(float value)
        {
            return Add("zoom", value);
        }

        public Transformation Zoom(double value)
        {
            return Add("zoom", value);
        }

        public Transformation Dpr(object value)
        {
            return Add("dpr", value);
        }

        public Transformation ResponsiveWidth(bool value)
        {
            return Add("responsive_width", value);
        }

        public Condition IfCondition()
        {
            return new Condition().SetParent(this);
        }

        public Transformation IfCondition(string condition)
        {
            return Add("if", condition);
        }

        public Transformation IfElse()
        {
            Chain();
            return Add("if", "else");
        }

        public Transformation EndIf()
        {
            Chain();
            for (var index = m_nestedTransforms.Count - 1; index >= 0; --index)
            {
                var nestedTransform = m_nestedTransforms[index];
                if (nestedTransform.Params.ContainsKey("if"))
                {
                    var obj = nestedTransform.Params["if"];
                    var b = obj.ToString();
                    if (!b.Equals("end"))
                    {
                        if (nestedTransform.Params.Count > 1)
                        {
                            nestedTransform.Params.Remove("if");
                            m_nestedTransforms[index] = nestedTransform;
                            m_nestedTransforms.Insert(index, new Transformation(string.Format("if={0}", obj.ToString())));
                        }
                        if (!string.Equals("else", b))
                            break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Add("if", "end");
            return Chain();
        }

        public Transformation VideoCodec(params string[] codecParams)
        {
            if (codecParams.Length == 1)
                return Add("video_codec", codecParams[0]);
            if (codecParams.Length <= 1 || codecParams.Length % 2 != 0)
                throw new ArgumentException("codecParams: please provide either single parameter or a bunch of key-value pairs (key1, value1, key2, value2, ...).");
            var codecParams1 = new Dictionary<string, string>();
            var index = 0;
            while (index < codecParams.Length)
            {
                if (!codecParams1.ContainsKey(codecParams[index]))
                    codecParams1.Add(codecParams[index], codecParams[index + 1]);
                index += 2;
            }
            return VideoCodec(codecParams1);
        }

        public Transformation VideoCodec(Dictionary<string, string> codecParams)
        {
            return Add("video_codec", codecParams);
        }

        public Transformation AudioCodec(string codec)
        {
            return Add("audio_codec", codec);
        }

        public Transformation BitRate(int bitRate)
        {
            return Add("bit_rate", bitRate);
        }

        public Transformation BitRate(string bitRate)
        {
            return Add("bit_rate", bitRate);
        }

        public Transformation AudioFrequency(int frequency)
        {
            return Add("audio_frequency", frequency);
        }

        public Transformation AudioFrequency(string frequency)
        {
            return Add("audio_frequency", frequency);
        }

        public Transformation VideoSampling(string value)
        {
            return Add("video_sampling", value);
        }

        public Transformation VideoSamplingFrames(int value)
        {
            return Add("video_sampling", value);
        }

        public Transformation VideoSamplingSeconds(int value)
        {
            return VideoSamplingSeconds((object) value);
        }

        public Transformation VideoSamplingSeconds(float value)
        {
            return VideoSamplingSeconds((object) value);
        }

        public Transformation VideoSamplingSeconds(double value)
        {
            return VideoSamplingSeconds((object) value);
        }

        private Transformation VideoSamplingSeconds(object value)
        {
            return Add("video_sampling", ToString(value) + "s");
        }

        public Transformation StartOffset(string value)
        {
            return Add("start_offset", value);
        }

        public Transformation StartOffset(float value)
        {
            return Add("start_offset", value);
        }

        public Transformation StartOffset(double value)
        {
            return Add("start_offset", value);
        }

        public Transformation StartOffsetPercent(float value)
        {
            return StartOffsetPercent((object) value);
        }

        public Transformation StartOffsetPercent(double value)
        {
            return StartOffsetPercent((object) value);
        }

        private Transformation StartOffsetPercent(object value)
        {
            return Add("start_offset", ToString(value) + "p");
        }

        public Transformation EndOffset(string value)
        {
            return Add("end_offset", value);
        }

        public Transformation EndOffset(float value)
        {
            return Add("end_offset", value);
        }

        public Transformation EndOffset(double value)
        {
            return Add("end_offset", value);
        }

        public Transformation EndOffsetPercent(float value)
        {
            return EndOffsetPercent((object) value);
        }

        public Transformation EndOffsetPercent(double value)
        {
            return EndOffsetPercent((object) value);
        }

        private Transformation EndOffsetPercent(object value)
        {
            return Add("end_offset", ToString(value) + "p");
        }

        public Transformation Offset(string value)
        {
            return Add("offset", value);
        }

        public Transformation Offset(params string[] value)
        {
            if (value.Length < 2)
                throw new ArgumentException("Offset range must include at least 2 items.");
            return Add("offset", value);
        }

        public Transformation Offset(params float[] value)
        {
            if (value.Length < 2)
                throw new ArgumentException("Offset range must include at least 2 items.");
            return Offset((object) value[0], (object) value[1]);
        }

        public Transformation Offset(params double[] value)
        {
            if (value.Length < 2)
                throw new ArgumentException("Offset range must include at least 2 items.");
            return Offset((object) value[0], (object) value[1]);
        }

        private Transformation Offset(params object[] value)
        {
            if (value.Length < 2)
                throw new ArgumentException("Offset range must include at least 2 items.");
            return Add("offset", value);
        }

        public Transformation Duration(string value)
        {
            return Add("duration", value);
        }

        public Transformation Duration(float value)
        {
            return Add("duration", value);
        }

        public Transformation Duration(double value)
        {
            return Add("duration", value);
        }

        public Transformation DurationPercent(float value)
        {
            return DurationPercent((object) value);
        }

        public Transformation DurationPercent(double value)
        {
            return DurationPercent((object) value);
        }

        private Transformation DurationPercent(object value)
        {
            return Add("duration", ToString(value) + "p");
        }

        private static void ProcessVideoCodec(SortedDictionary<string, string> parameters, Dictionary<string, object> m_transformParams)
        {
            object obj = null;
            if (!m_transformParams.TryGetValue("video_codec", out obj))
                return;
            var stringBuilder = new StringBuilder();
            if (obj is string)
            {
                stringBuilder.Append(obj);
            }
            else if (obj is Dictionary<string, string>)
            {
                string str = null;
                var dictionary = (Dictionary<string, string>) obj;
                if (!dictionary.TryGetValue("codec", out str))
                    return;
                stringBuilder.Append(str);
                if (dictionary.TryGetValue("profile", out str))
                {
                    stringBuilder.Append(":").Append(str);
                    if (dictionary.TryGetValue("level", out str))
                        stringBuilder.Append(":").Append(str);
                }
            }
            parameters.Add("vc", stringBuilder.ToString());
        }

        private static string NormRangeValue(object objectValue)
        {
            if (objectValue == null)
                return null;
            var input = ToString(objectValue);
            if (string.IsNullOrEmpty(input))
                return null;
            var match = RANGE_VALUE_RE.Match(input);
            if (!match.Success)
                return null;
            var str = "";
            if (match.Groups.Count == 3 && !string.IsNullOrEmpty(match.Groups[2].Value))
                str = "p";
            return match.Groups[1] + str;
        }

        private static string[] SplitRange(object range)
        {
            if (range is string)
            {
                var input = (string) range;
                if (RANGE_RE.IsMatch(input))
                    return input.Split(new string[1] {".."}, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (range is Array)
            {
                var array = (Array) range;
                var strArray = new string[array.Length];
                for (var index = 0; index < array.Length; ++index)
                    strArray[index] = ToString(array.GetValue(index));
                return strArray;
            }
            return null;
        }

        public Transformation Chain()
        {
            var transformation = Clone();
            transformation.m_nestedTransforms = null;
            m_nestedTransforms.Add(transformation);
            m_transformParams = new Dictionary<string, object>();
            return new Transformation(m_nestedTransforms);
        }

        public Transformation Add(string key, object value)
        {
            if (m_transformParams.ContainsKey(key))
                m_transformParams[key] = value;
            else
                m_transformParams.Add(key, value);
            return this;
        }

        public virtual string Generate()
        {
            var source = new HashSet<string>(m_nestedTransforms.Select(t => t.GenerateThis()).ToList());
            var str = GenerateThis();
            if (!string.IsNullOrEmpty(str))
                source.Add(str);
            return string.Join("/", source.ToArray());
        }

        public string GenerateThis()
        {
            var str1 = GetString(m_transformParams, "size");
            if (str1 != null)
            {
                var strArray = str1.Split("x".ToArray());
                m_transformParams.Add("width", strArray[0]);
                m_transformParams.Add("height", strArray[1]);
            }
            var s1 = GetString(m_transformParams, "width");
            var s2 = GetString(m_transformParams, "height");
            if (m_htmlWidth == null)
                m_htmlWidth = s1;
            if (m_htmlHeight == null)
                m_htmlHeight = s2;
            var flag1 = !string.IsNullOrEmpty(GetString(m_transformParams, "overlay")) || !string.IsNullOrEmpty(GetString(m_transformParams, "underlay"));
            var str2 = GetString(m_transformParams, "crop");
            var str3 = string.Join(".", GetStringArray(m_transformParams, "angle"));
            var result = false;
            if (!bool.TryParse(GetString(m_transformParams, "responsive_width"), out result))
                result = DefaultIsResponsive;
            var flag2 = flag1 || !string.IsNullOrEmpty(str3) || str2 == "fit" || str2 == "limit";
            if (s1 != null && (s1 == "auto" || float.Parse(s1, CultureInfo.InvariantCulture) < 1.0 || flag2 || result))
                m_htmlWidth = null;
            if (s2 != null && (float.Parse(s2, CultureInfo.InvariantCulture) < 1.0 || flag2 || result))
                m_htmlHeight = null;
            var str4 = GetString(m_transformParams, "background");
            if (str4 != null)
                str4 = str4.Replace("^#", "rgb:");
            var str5 = GetString(m_transformParams, "color");
            if (str5 != null)
                str5 = str5.Replace("^#", "rgb:");
            var str6 = string.Join(".", GetStringArray(m_transformParams, "transformation").ToList().ToArray());
            var stringList1 = new List<string>();
            var str7 = string.Join(".", GetStringArray(m_transformParams, "flags"));
            object objectValue = null;
            string str8 = null;
            string str9 = null;
            if (m_transformParams.TryGetValue("start_offset", out objectValue))
                str8 = NormRangeValue(objectValue);
            if (m_transformParams.TryGetValue("end_offset", out objectValue))
                str9 = NormRangeValue(objectValue);
            if (m_transformParams.TryGetValue("offset", out objectValue))
            {
                var strArray = SplitRange(m_transformParams["offset"]);
                if (strArray != null && strArray.Length == 2)
                {
                    str8 = NormRangeValue(strArray[0]);
                    str9 = NormRangeValue(strArray[1]);
                }
            }
            var parameters = new SortedDictionary<string, string>();
            parameters.Add("w", s1);
            parameters.Add("h", s2);
            parameters.Add("t", str6);
            parameters.Add("c", str2);
            parameters.Add("b", str4);
            parameters.Add("co", str5);
            parameters.Add("a", str3);
            parameters.Add("fl", str7);
            parameters.Add("so", str8);
            parameters.Add("eo", str9);
            if (m_transformParams.TryGetValue("duration", out objectValue))
                parameters.Add("du", NormRangeValue(objectValue));
            ProcessVideoCodec(parameters, m_transformParams);
            var index = 0;
            while (index < SimpleParams.Length)
            {
                if (m_transformParams.TryGetValue(SimpleParams[index + 1], out objectValue))
                    parameters.Add(SimpleParams[index], ToString(objectValue));
                index += 2;
            }
            object obj = null;
            if (!m_transformParams.TryGetValue("dpr", out obj))
                obj = DefaultDpr;
            var str10 = ToString(obj);
            if (str10 != null)
            {
                if (str10.ToLower() == "auto")
                    HiDpi = true;
                parameters.Add("dpr", str10);
            }
            if (s1 == "auto" || result)
                IsResponsive = true;
            var stringList2 = new List<string>();
            foreach (var keyValuePair in parameters)
                if (!string.IsNullOrEmpty(keyValuePair.Value))
                    stringList2.Add(string.Format("{0}_{1}", keyValuePair.Key, keyValuePair.Value));
            var str11 = GetString(m_transformParams, "raw_transformation");
            if (str11 != null)
                stringList2.Add(str11);
            var condition = GetString(m_transformParams, "if");
            if (!string.IsNullOrEmpty(condition))
                stringList2.Insert(0, string.Format("if_{0}", new Condition(condition).ToString()));
            if (stringList2.Count > 0)
                stringList1.Add(string.Join(",", stringList2.ToArray()));
            if (result)
                stringList1.Add(ResponsiveWidthTransform.Generate());
            return string.Join("/", stringList1.ToArray());
        }

        private string[] GetStringArray(Dictionary<string, object> options, string key)
        {
            if (!options.ContainsKey(key))
                return new string[0];
            var option = options[key];
            if (option is string[])
                return (string[]) option;
            return new List<string> {ToString(option)}.ToArray();
        }

        private string GetString(Dictionary<string, object> options, string key)
        {
            if (options.ContainsKey(key))
                return ToString(options[key]);
            return null;
        }

        private static string ToString(object obj)
        {
            if (obj == null)
                return null;
            if (obj is string)
                return obj.ToString();
            if (obj is float || obj is double)
                return string.Format(CultureInfo.InvariantCulture, "{0:0.0#}", new object[1] {obj});
            return string.Format(CultureInfo.InvariantCulture, "{0}", new object[1] {obj});
        }

        public override string ToString()
        {
            return Generate();
        }

        public Transformation Clone()
        {
            var transformation = (Transformation) MemberwiseClone();
            transformation.m_transformParams = new Dictionary<string, object>();
            foreach (var key in m_transformParams.Keys)
            {
                var transformParam = m_transformParams[key];
                if (transformParam is Array)
                {
                    transformation.Add(key, ((Array) transformParam).Clone());
                }
                else if (transformParam is string || transformParam is ValueType)
                {
                    transformation.Add(key, transformParam);
                }
                else
                {
                    if (!(transformParam is Dictionary<string, string>))
                        throw new CloudinaryException(string.Format("Couldn't clone parameter '{0}'!", key));
                    transformation.Add(key, new Dictionary<string, string>((IDictionary<string, string>) transformParam));
                }
            }
            if (m_nestedTransforms != null)
            {
                transformation.m_nestedTransforms = new List<Transformation>();
                foreach (var nestedTransform in m_nestedTransforms)
                    transformation.m_nestedTransforms.Add(nestedTransform.Clone());
            }
            return transformation;
        }

        //}
        //   return (object) this.Clone();
        // {

        //object ICloneable.Clone()
    }
}