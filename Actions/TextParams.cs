// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.TextParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;

namespace CloudinaryDotNet.Actions
{
  public class TextParams : BaseParams
  {
    public string Text { get; set; }

    public string PublicId { get; set; }

    public string FontFamily { get; set; }

    public int FontSize { get; set; }

    public string FontColor { get; set; }

    [Obsolete("Property FontWeitgh is deprecated, please use FontWeight instead")]
    public string FontWeitgh
    {
      get
      {
        return this.FontWeight;
      }
      set
      {
        this.FontWeight = value;
      }
    }

    public string FontWeight { get; set; }

    public string FontStyle { get; set; }

    public string Background { get; set; }

    public string Opacity { get; set; }

    public string TextDecoration { get; set; }

    public string TextAlign { get; set; }

    public TextParams()
    {
      this.FontSize = 12;
    }

    public TextParams(string text)
      : this()
    {
      this.Text = text;
    }

    public override void Check()
    {
      if (string.IsNullOrEmpty(this.Text))
        throw new ArgumentException("Text must be specified in TextParams!");
    }

    public override SortedDictionary<string, object> ToParamsDictionary()
    {
      SortedDictionary<string, object> paramsDictionary = base.ToParamsDictionary();
      this.AddParam(paramsDictionary, "text", this.Text);
      this.AddParam(paramsDictionary, "public_id", this.PublicId);
      this.AddParam(paramsDictionary, "font_family", this.FontFamily);
      this.AddParam(paramsDictionary, "font_size", this.FontSize.ToString());
      this.AddParam(paramsDictionary, "font_color", this.FontColor);
      this.AddParam(paramsDictionary, "font_weight", this.FontWeight);
      this.AddParam(paramsDictionary, "font_style", this.FontStyle);
      this.AddParam(paramsDictionary, "background", this.Background);
      this.AddParam(paramsDictionary, "opacity", this.Opacity);
      this.AddParam(paramsDictionary, "text_decoration", this.TextDecoration);
      this.AddParam(paramsDictionary, "text_align", this.TextAlign);
      return paramsDictionary;
    }
  }
}
