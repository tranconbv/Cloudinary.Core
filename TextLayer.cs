// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.TextLayer
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Web;

namespace CloudinaryDotNet
{
  public class TextLayer : BaseLayer<TextLayer>
  {
    protected string m_text;
    protected string m_fontFamily;
    protected int m_fontSize;
    protected string m_fontWeight;
    protected string m_fontStyle;
    protected string m_textDecoration;
    protected string m_textAlign;
    protected string m_stroke;
    protected string m_letterSpacing;
    protected string m_lineSpacing;

    public TextLayer()
    {
      this.m_resourceType = "text";
      this.FontSize(12);
    }

    public TextLayer(string text)
      : this()
    {
      this.Text(text);
    }

    public new TextLayer ResourceType(string resourceType)
    {
      throw new InvalidOperationException("Cannot modify resourceType for text layers");
    }

    public new TextLayer Type(string type)
    {
      throw new InvalidOperationException("Cannot modify type for text layers");
    }

    public new TextLayer Format(string format)
    {
      throw new InvalidOperationException("Cannot modify format for text layers");
    }

    public TextLayer Text(string text)
    {
      this.m_text = this.OverlayTextEncode(text);
      return this;
    }

    private string OverlayTextEncode(string text)
    {
      return HttpUtility.UrlEncodeUnicode(text).Replace("%2f", "/").Replace("%3a", ":").Replace("+", "%20").Replace("%2c", "%e2%80%9a").Replace("/", "%e2%81%84");
    }

    public TextLayer FontFamily(string fontFamily)
    {
      this.m_fontFamily = fontFamily;
      return this;
    }

    public TextLayer FontSize(int fontSize)
    {
      this.m_fontSize = fontSize;
      return this;
    }

    public TextLayer FontWeight(string fontWeight)
    {
      this.m_fontWeight = fontWeight;
      return this;
    }

    public TextLayer FontStyle(string fontStyle)
    {
      this.m_fontStyle = fontStyle;
      return this;
    }

    public TextLayer TextDecoration(string textDecoration)
    {
      this.m_textDecoration = textDecoration;
      return this;
    }

    public TextLayer TextAlign(string textAlign)
    {
      this.m_textAlign = textAlign;
      return this;
    }

    public TextLayer Stroke(string stroke)
    {
      this.m_stroke = stroke;
      return this;
    }

    public TextLayer LetterSpacing(string letterSpacing)
    {
      this.m_letterSpacing = letterSpacing;
      return this;
    }

    public TextLayer LineSpacing(string lineSpacing)
    {
      this.m_lineSpacing = lineSpacing;
      return this;
    }

    public override string AdditionalParams()
    {
      List<string> stringList = new List<string>();
      string str = this.TextStyleIdentifier();
      if (!string.IsNullOrEmpty(str))
        stringList.Add(str);
      if (!string.IsNullOrEmpty(this.m_text))
        stringList.Add(this.m_text);
      return string.Join(":", stringList.ToArray());
    }

    public override string ToString()
    {
      if (string.IsNullOrEmpty(this.m_publicId) && string.IsNullOrEmpty(this.m_text))
        throw new ArgumentException("Must supply either text or publicId.");
      return base.ToString();
    }

    private string TextStyleIdentifier()
    {
      List<string> stringList = new List<string>();
      if (!string.IsNullOrEmpty(this.m_fontWeight) && !this.m_fontWeight.Equals("normal"))
        stringList.Add(this.m_fontWeight);
      if (!string.IsNullOrEmpty(this.m_fontStyle) && !this.m_fontStyle.Equals("normal"))
        stringList.Add(this.m_fontStyle);
      if (!string.IsNullOrEmpty(this.m_textDecoration) && !this.m_textDecoration.Equals("none"))
        stringList.Add(this.m_textDecoration);
      if (!string.IsNullOrEmpty(this.m_textAlign))
        stringList.Add(this.m_textAlign);
      if (!string.IsNullOrEmpty(this.m_stroke) && !this.m_stroke.Equals("none"))
        stringList.Add(this.m_stroke);
      if (!string.IsNullOrEmpty(this.m_letterSpacing))
        stringList.Add(string.Format("letter_spacing_{0}", (object) this.m_letterSpacing));
      if (!string.IsNullOrEmpty(this.m_lineSpacing))
        stringList.Add(string.Format("line_spacing_{0}", (object) this.m_lineSpacing));
      if (string.IsNullOrEmpty(this.m_fontFamily) && stringList.Count == 0)
        return (string) null;
      if (string.IsNullOrEmpty(this.m_fontFamily))
        throw new ArgumentException("Must supply fontFamily.");
      stringList.Insert(0, this.m_fontSize.ToString());
      stringList.Insert(0, this.m_fontFamily);
      return string.Join("_", stringList.ToArray());
    }
  }
}
