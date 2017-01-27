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
  public class Transformation  //: ICloneable, lets not even go there: http://stackoverflow.com/a/20386650/1275832
    {
    private static readonly Regex RANGE_VALUE_RE = new Regex("^((?:\\d+\\.)?\\d+)([%pP])?$", RegexOptions.Compiled);
    private static readonly Regex RANGE_RE = new Regex("^(\\d+\\.)?\\d+[%pP]?\\.\\.(\\d+\\.)?\\d+[%pP]?$", RegexOptions.Compiled);
    private static readonly string[] SimpleParams = new string[46]{ "x", "x", "y", "y", "r", "radius", "d", "default_image", "g", "gravity", "cs", "color_space", "p", "prefix", "l", "overlay", "u", "underlay", "f", "fetch_format", "dn", "density", "pg", "page", "dl", "delay", "e", "effect", "bo", "border", "q", "quality", "o", "opacity", "z", "zoom", "ac", "audio_codec", "br", "bit_rate", "af", "audio_frequency", "ar", "aspect_ratio", "vs", "video_sampling" };
    private static readonly Transformation DEFAULT_RESPONSIVE_WIDTH_TRANSFORM = new Transformation().Width((object) "auto").Crop("limit");
    private static Transformation m_responsiveWidthTransform = (Transformation) null;
    protected Dictionary<string, object> m_transformParams = new Dictionary<string, object>();
    protected List<Transformation> m_nestedTransforms = new List<Transformation>();
    protected string m_htmlWidth;
    protected string m_htmlHeight;

    public static object DefaultDpr { get; set; }

    public static bool DefaultIsResponsive { get; set; }

    public static Transformation ResponsiveWidthTransform
    {
      get
      {
        if (Transformation.m_responsiveWidthTransform == null)
          return Transformation.DEFAULT_RESPONSIVE_WIDTH_TRANSFORM;
        return Transformation.m_responsiveWidthTransform;
      }
      set
      {
        Transformation.m_responsiveWidthTransform = value;
      }
    }

    public Dictionary<string, object> Params
    {
      get
      {
        return this.m_transformParams;
      }
    }

    public List<Transformation> NestedTransforms
    {
      get
      {
        return this.m_nestedTransforms;
      }
    }

    public bool HiDpi { get; private set; }

    public bool IsResponsive { get; private set; }

    public string HtmlWidth
    {
      get
      {
        return this.m_htmlWidth;
      }
    }

    public string HtmlHeight
    {
      get
      {
        return this.m_htmlHeight;
      }
    }

    public Transformation()
    {
    }

    public Transformation(List<Transformation> transforms)
    {
      if (transforms == null)
        return;
      this.m_nestedTransforms = transforms;
    }

    public Transformation(params string[] transformParams)
    {
      foreach (string transformParam in transformParams)
      {
        string[] strArray = transformParam.Split('=');
        if (strArray.Length != 2)
          throw new ArgumentException(string.Format("Couldn't parse '{0}'!", (object) transformParam));
        this.Add(strArray[0], (object) strArray[1]);
      }
    }

    public Transformation(Dictionary<string, object> transformParams)
    {
      foreach (string key in transformParams.Keys)
        this.m_transformParams.Add(key, transformParams[key]);
    }

    public Transformation(Dictionary<string, object>[] dictionary)
    {
      for (int index = 0; index < dictionary.Length; ++index)
      {
        if (index == dictionary.Length - 1)
          this.m_transformParams = dictionary[index];
        else
          this.m_nestedTransforms.Add(new Transformation(dictionary[index]));
      }
    }

    public Transformation Width(object value)
    {
      return this.Add("width", value);
    }

    public Transformation Height(object value)
    {
      return this.Add("height", value);
    }

    public Transformation SetHtmlWidth(object value)
    {
      this.m_htmlWidth = value.ToString();
      return this;
    }

    public Transformation SetHtmlHeight(object value)
    {
      this.m_htmlHeight = value.ToString();
      return this;
    }

    public Transformation Named(params string[] value)
    {
      return this.Add("transformation", (object) value);
    }

    public Transformation AspectRatio(double value)
    {
      return this.AspectRatio(value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    public Transformation AspectRatio(int nom, int denom)
    {
      return this.AspectRatio(string.Format("{0}:{1}", (object) nom, (object) denom));
    }

    public Transformation AspectRatio(string value)
    {
      return this.Add("aspect_ratio", (object) value);
    }

    public Transformation Crop(string value)
    {
      return this.Add("crop", (object) value);
    }

    public Transformation Background(string value)
    {
      return this.Add("background", (object) Regex.Replace(value, "^#", "rgb:"));
    }

    public Transformation Color(string value)
    {
      return this.Add("color", (object) Regex.Replace(value, "^#", "rgb:"));
    }

    public Transformation Effect(string value)
    {
      return this.Add("effect", (object) value);
    }

    public Transformation Effect(string effect, object param)
    {
      return this.Add("effect", (object) (effect + ":" + param));
    }

    public Transformation Angle(int value)
    {
      return this.Add("angle", (object) value);
    }

    public Transformation Angle(params string[] value)
    {
      return this.Add("angle", (object) value);
    }

    public Transformation Border(string value)
    {
      return this.Add("border", (object) value);
    }

    public Transformation Border(int width, string color)
    {
      return this.Add("border", (object) (width.ToString() + "px_solid_" + Regex.Replace(color, "^#", "rgb:")));
    }

    public Transformation X(object value)
    {
      return this.Add("x", value);
    }

    public Transformation Y(object value)
    {
      return this.Add("y", value);
    }

    public Transformation Radius(object value)
    {
      return this.Add("radius", value);
    }

    public Transformation Quality(object value)
    {
      return this.Add("quality", value);
    }

    public Transformation DefaultImage(string value)
    {
      return this.Add("default_image", (object) value);
    }

    public Transformation Gravity(string value)
    {
      return this.Add("gravity", (object) value);
    }

    public Transformation ColorSpace(string value)
    {
      return this.Add("color_space", (object) value);
    }

    public Transformation Prefix(string value)
    {
      return this.Add("prefix", (object) value);
    }

    public Transformation Opacity(int value)
    {
      return this.Add("opacity", (object) value);
    }

    public Transformation Overlay(string value)
    {
      return this.Add("overlay", (object) value);
    }

    public Transformation Overlay(BaseLayer value)
    {
      return this.Add("overlay", (object) value);
    }

    public Transformation Underlay(string value)
    {
      return this.Add("underlay", (object) value);
    }

    public Transformation Underlay(BaseLayer value)
    {
      return this.Add("underlay", (object) value);
    }

    public Transformation FetchFormat(string value)
    {
      return this.Add("fetch_format", (object) value);
    }

    public Transformation Density(object value)
    {
      return this.Add("density", value);
    }

    public Transformation Page(object value)
    {
      return this.Add("page", value);
    }

    public Transformation Delay(object value)
    {
      return this.Add("delay", value);
    }

    public Transformation RawTransformation(string value)
    {
      return this.Add("raw_transformation", (object) value);
    }

    public Transformation Flags(params string[] value)
    {
      return this.Add("flags", (object) value);
    }

    public Transformation Zoom(int value)
    {
      return this.Add("zoom", (object) value);
    }

    public Transformation Zoom(string value)
    {
      return this.Add("zoom", (object) value);
    }

    public Transformation Zoom(float value)
    {
      return this.Add("zoom", (object) value);
    }

    public Transformation Zoom(double value)
    {
      return this.Add("zoom", (object) value);
    }

    public Transformation Dpr(object value)
    {
      return this.Add("dpr", value);
    }

    public Transformation ResponsiveWidth(bool value)
    {
      return this.Add("responsive_width", (object) value);
    }

    public Condition IfCondition()
    {
      return new Condition().SetParent(this);
    }

    public Transformation IfCondition(string condition)
    {
      return this.Add("if", (object) condition);
    }

    public Transformation IfElse()
    {
      this.Chain();
      return this.Add("if", (object) "else");
    }

    public Transformation EndIf()
    {
      this.Chain();
      for (int index = this.m_nestedTransforms.Count - 1; index >= 0; --index)
      {
        Transformation nestedTransform = this.m_nestedTransforms[index];
        if (nestedTransform.Params.ContainsKey("if"))
        {
          object obj = nestedTransform.Params["if"];
          string b = obj.ToString();
          if (!b.Equals("end"))
          {
            if (nestedTransform.Params.Count > 1)
            {
              nestedTransform.Params.Remove("if");
              this.m_nestedTransforms[index] = nestedTransform;
              this.m_nestedTransforms.Insert(index, new Transformation(new string[1]
              {
                string.Format("if={0}", (object) obj.ToString())
              }));
            }
            if (!string.Equals("else", b))
              break;
          }
          else
            break;
        }
      }
      this.Add("if", (object) "end");
      return this.Chain();
    }

    public Transformation VideoCodec(params string[] codecParams)
    {
      if (codecParams.Length == 1)
        return this.Add("video_codec", (object) codecParams[0]);
      if (codecParams.Length <= 1 || codecParams.Length % 2 != 0)
        throw new ArgumentException("codecParams: please provide either single parameter or a bunch of key-value pairs (key1, value1, key2, value2, ...).");
      Dictionary<string, string> codecParams1 = new Dictionary<string, string>();
      int index = 0;
      while (index < codecParams.Length)
      {
        if (!codecParams1.ContainsKey(codecParams[index]))
          codecParams1.Add(codecParams[index], codecParams[index + 1]);
        index += 2;
      }
      return this.VideoCodec(codecParams1);
    }

    public Transformation VideoCodec(Dictionary<string, string> codecParams)
    {
      return this.Add("video_codec", (object) codecParams);
    }

    public Transformation AudioCodec(string codec)
    {
      return this.Add("audio_codec", (object) codec);
    }

    public Transformation BitRate(int bitRate)
    {
      return this.Add("bit_rate", (object) bitRate);
    }

    public Transformation BitRate(string bitRate)
    {
      return this.Add("bit_rate", (object) bitRate);
    }

    public Transformation AudioFrequency(int frequency)
    {
      return this.Add("audio_frequency", (object) frequency);
    }

    public Transformation AudioFrequency(string frequency)
    {
      return this.Add("audio_frequency", (object) frequency);
    }

    public Transformation VideoSampling(string value)
    {
      return this.Add("video_sampling", (object) value);
    }

    public Transformation VideoSamplingFrames(int value)
    {
      return this.Add("video_sampling", (object) value);
    }

    public Transformation VideoSamplingSeconds(int value)
    {
      return this.VideoSamplingSeconds((object) value);
    }

    public Transformation VideoSamplingSeconds(float value)
    {
      return this.VideoSamplingSeconds((object) value);
    }

    public Transformation VideoSamplingSeconds(double value)
    {
      return this.VideoSamplingSeconds((object) value);
    }

    private Transformation VideoSamplingSeconds(object value)
    {
      return this.Add("video_sampling", (object) (Transformation.ToString(value) + "s"));
    }

    public Transformation StartOffset(string value)
    {
      return this.Add("start_offset", (object) value);
    }

    public Transformation StartOffset(float value)
    {
      return this.Add("start_offset", (object) value);
    }

    public Transformation StartOffset(double value)
    {
      return this.Add("start_offset", (object) value);
    }

    public Transformation StartOffsetPercent(float value)
    {
      return this.StartOffsetPercent((object) value);
    }

    public Transformation StartOffsetPercent(double value)
    {
      return this.StartOffsetPercent((object) value);
    }

    private Transformation StartOffsetPercent(object value)
    {
      return this.Add("start_offset", (object) (Transformation.ToString(value) + "p"));
    }

    public Transformation EndOffset(string value)
    {
      return this.Add("end_offset", (object) value);
    }

    public Transformation EndOffset(float value)
    {
      return this.Add("end_offset", (object) value);
    }

    public Transformation EndOffset(double value)
    {
      return this.Add("end_offset", (object) value);
    }

    public Transformation EndOffsetPercent(float value)
    {
      return this.EndOffsetPercent((object) value);
    }

    public Transformation EndOffsetPercent(double value)
    {
      return this.EndOffsetPercent((object) value);
    }

    private Transformation EndOffsetPercent(object value)
    {
      return this.Add("end_offset", (object) (Transformation.ToString(value) + "p"));
    }

    public Transformation Offset(string value)
    {
      return this.Add("offset", (object) value);
    }

    public Transformation Offset(params string[] value)
    {
      if (value.Length < 2)
        throw new ArgumentException("Offset range must include at least 2 items.");
      return this.Add("offset", (object) value);
    }

    public Transformation Offset(params float[] value)
    {
      if (value.Length < 2)
        throw new ArgumentException("Offset range must include at least 2 items.");
      return this.Offset((object) value[0], (object) value[1]);
    }

    public Transformation Offset(params double[] value)
    {
      if (value.Length < 2)
        throw new ArgumentException("Offset range must include at least 2 items.");
      return this.Offset((object) value[0], (object) value[1]);
    }

    private Transformation Offset(params object[] value)
    {
      if (value.Length < 2)
        throw new ArgumentException("Offset range must include at least 2 items.");
      return this.Add("offset", (object) value);
    }

    public Transformation Duration(string value)
    {
      return this.Add("duration", (object) value);
    }

    public Transformation Duration(float value)
    {
      return this.Add("duration", (object) value);
    }

    public Transformation Duration(double value)
    {
      return this.Add("duration", (object) value);
    }

    public Transformation DurationPercent(float value)
    {
      return this.DurationPercent((object) value);
    }

    public Transformation DurationPercent(double value)
    {
      return this.DurationPercent((object) value);
    }

    private Transformation DurationPercent(object value)
    {
      return this.Add("duration", (object) (Transformation.ToString(value) + "p"));
    }

    private static void ProcessVideoCodec(SortedDictionary<string, string> parameters, Dictionary<string, object> m_transformParams)
    {
      object obj = (object) null;
      if (!m_transformParams.TryGetValue("video_codec", out obj))
        return;
      StringBuilder stringBuilder = new StringBuilder();
      if (obj is string)
        stringBuilder.Append(obj);
      else if (obj is Dictionary<string, string>)
      {
        string str = (string) null;
        Dictionary<string, string> dictionary = (Dictionary<string, string>) obj;
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
        return (string) null;
      string input = Transformation.ToString(objectValue);
      if (string.IsNullOrEmpty(input))
        return (string) null;
      Match match = Transformation.RANGE_VALUE_RE.Match(input);
      if (!match.Success)
        return (string) null;
      string str = "";
      if (match.Groups.Count == 3 && !string.IsNullOrEmpty(match.Groups[2].Value))
        str = "p";
      return match.Groups[1].ToString() + str;
    }

    private static string[] SplitRange(object range)
    {
      if (range is string)
      {
        string input = (string) range;
        if (Transformation.RANGE_RE.IsMatch(input))
          return input.Split(new string[1]{ ".." }, StringSplitOptions.RemoveEmptyEntries);
      }
      else if (range is Array)
      {
        Array array = (Array) range;
        string[] strArray = new string[array.Length];
        for (int index = 0; index < array.Length; ++index)
          strArray[index] = Transformation.ToString(array.GetValue(index));
        return strArray;
      }
      return (string[]) null;
    }

    public Transformation Chain()
    {
      Transformation transformation = this.Clone();
      transformation.m_nestedTransforms = (List<Transformation>) null;
      this.m_nestedTransforms.Add(transformation);
      this.m_transformParams = new Dictionary<string, object>();
      return new Transformation(this.m_nestedTransforms);
    }

    public Transformation Add(string key, object value)
    {
      if (this.m_transformParams.ContainsKey(key))
        this.m_transformParams[key] = value;
      else
        this.m_transformParams.Add(key, value);
      return this;
    }

    public virtual string Generate()
    {
      HashSet<string> source = new HashSet<string>((IEnumerable<string>) this.m_nestedTransforms.Select<Transformation, string>((Func<Transformation, string>) (t => t.GenerateThis())).ToList<string>());
      string str = this.GenerateThis();
      if (!string.IsNullOrEmpty(str))
        source.Add(str);
      return string.Join("/", source.ToArray<string>());
    }

    public string GenerateThis()
    {
      string str1 = this.GetString(this.m_transformParams, "size");
      if (str1 != null)
      {
        string[] strArray = str1.Split("x".ToArray<char>());
        this.m_transformParams.Add("width", (object) strArray[0]);
        this.m_transformParams.Add("height", (object) strArray[1]);
      }
      string s1 = this.GetString(this.m_transformParams, "width");
      string s2 = this.GetString(this.m_transformParams, "height");
      if (this.m_htmlWidth == null)
        this.m_htmlWidth = s1;
      if (this.m_htmlHeight == null)
        this.m_htmlHeight = s2;
      bool flag1 = !string.IsNullOrEmpty(this.GetString(this.m_transformParams, "overlay")) || !string.IsNullOrEmpty(this.GetString(this.m_transformParams, "underlay"));
      string str2 = this.GetString(this.m_transformParams, "crop");
      string str3 = string.Join(".", this.GetStringArray(this.m_transformParams, "angle"));
      bool result = false;
      if (!bool.TryParse(this.GetString(this.m_transformParams, "responsive_width"), out result))
        result = Transformation.DefaultIsResponsive;
      bool flag2 = flag1 || !string.IsNullOrEmpty(str3) || str2 == "fit" || str2 == "limit";
      if (s1 != null && (s1 == "auto" || (double) float.Parse(s1, (IFormatProvider) CultureInfo.InvariantCulture) < 1.0 || (flag2 || result)))
        this.m_htmlWidth = (string) null;
      if (s2 != null && ((double) float.Parse(s2, (IFormatProvider) CultureInfo.InvariantCulture) < 1.0 || flag2 || result))
        this.m_htmlHeight = (string) null;
      string str4 = this.GetString(this.m_transformParams, "background");
      if (str4 != null)
        str4 = str4.Replace("^#", "rgb:");
      string str5 = this.GetString(this.m_transformParams, "color");
      if (str5 != null)
        str5 = str5.Replace("^#", "rgb:");
      string str6 = string.Join(".", ((IEnumerable<string>) this.GetStringArray(this.m_transformParams, "transformation")).ToList<string>().ToArray());
      List<string> stringList1 = new List<string>();
      string str7 = string.Join(".", this.GetStringArray(this.m_transformParams, "flags"));
      object objectValue = (object) null;
      string str8 = (string) null;
      string str9 = (string) null;
      if (this.m_transformParams.TryGetValue("start_offset", out objectValue))
        str8 = Transformation.NormRangeValue(objectValue);
      if (this.m_transformParams.TryGetValue("end_offset", out objectValue))
        str9 = Transformation.NormRangeValue(objectValue);
      if (this.m_transformParams.TryGetValue("offset", out objectValue))
      {
        string[] strArray = Transformation.SplitRange(this.m_transformParams["offset"]);
        if (strArray != null && strArray.Length == 2)
        {
          str8 = Transformation.NormRangeValue((object) strArray[0]);
          str9 = Transformation.NormRangeValue((object) strArray[1]);
        }
      }
      SortedDictionary<string, string> parameters = new SortedDictionary<string, string>();
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
      if (this.m_transformParams.TryGetValue("duration", out objectValue))
        parameters.Add("du", Transformation.NormRangeValue(objectValue));
      Transformation.ProcessVideoCodec(parameters, this.m_transformParams);
      int index = 0;
      while (index < Transformation.SimpleParams.Length)
      {
        if (this.m_transformParams.TryGetValue(Transformation.SimpleParams[index + 1], out objectValue))
          parameters.Add(Transformation.SimpleParams[index], Transformation.ToString(objectValue));
        index += 2;
      }
      object obj = (object) null;
      if (!this.m_transformParams.TryGetValue("dpr", out obj))
        obj = Transformation.DefaultDpr;
      string str10 = Transformation.ToString(obj);
      if (str10 != null)
      {
        if (str10.ToLower() == "auto")
          this.HiDpi = true;
        parameters.Add("dpr", str10);
      }
      if (s1 == "auto" || result)
        this.IsResponsive = true;
      List<string> stringList2 = new List<string>();
      foreach (KeyValuePair<string, string> keyValuePair in parameters)
      {
        if (!string.IsNullOrEmpty(keyValuePair.Value))
          stringList2.Add(string.Format("{0}_{1}", (object) keyValuePair.Key, (object) keyValuePair.Value));
      }
      string str11 = this.GetString(this.m_transformParams, "raw_transformation");
      if (str11 != null)
        stringList2.Add(str11);
      string condition = this.GetString(this.m_transformParams, "if");
      if (!string.IsNullOrEmpty(condition))
        stringList2.Insert(0, string.Format("if_{0}", (object) new Condition(condition).ToString()));
      if (stringList2.Count > 0)
        stringList1.Add(string.Join(",", stringList2.ToArray()));
      if (result)
        stringList1.Add(Transformation.ResponsiveWidthTransform.Generate());
      return string.Join("/", stringList1.ToArray());
    }

    private string[] GetStringArray(Dictionary<string, object> options, string key)
    {
      if (!options.ContainsKey(key))
        return new string[0];
      object option = options[key];
      if (option is string[])
        return (string[]) option;
      return new List<string>() { Transformation.ToString(option) }.ToArray();
    }

    private string GetString(Dictionary<string, object> options, string key)
    {
      if (options.ContainsKey(key))
        return Transformation.ToString(options[key]);
      return (string) null;
    }

    private static string ToString(object obj)
    {
      if (obj == null)
        return (string) null;
      if (obj is string)
        return obj.ToString();
      if (obj is float || obj is double)
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0:0.0#}", new object[1]{ obj });
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}", new object[1]{ obj });
    }

    public override string ToString()
    {
      return this.Generate();
    }

    public Transformation Clone()
    {
      Transformation transformation = (Transformation) this.MemberwiseClone();
      transformation.m_transformParams = new Dictionary<string, object>();
      foreach (string key in this.m_transformParams.Keys)
      {
        object transformParam = this.m_transformParams[key];
        if (transformParam is Array)
          transformation.Add(key, ((Array) transformParam).Clone());
        else if (transformParam is string || transformParam is ValueType)
        {
          transformation.Add(key, transformParam);
        }
        else
        {
          if (!(transformParam is Dictionary<string, string>))
            throw new CloudinaryException(string.Format("Couldn't clone parameter '{0}'!", (object) key));
          transformation.Add(key, (object) new Dictionary<string, string>((IDictionary<string, string>) transformParam));
        }
      }
      if (this.m_nestedTransforms != null)
      {
        transformation.m_nestedTransforms = new List<Transformation>();
        foreach (Transformation nestedTransform in this.m_nestedTransforms)
          transformation.m_nestedTransforms.Add(nestedTransform.Clone());
      }
      return transformation;
    }

    //object ICloneable.Clone()
   // {
   //   return (object) this.Clone();
    //}
  }
}
