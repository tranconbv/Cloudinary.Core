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
        public TextParams()
        {
            FontSize = 12;
        }

        public TextParams(string text)
            : this()
        {
            Text = text;
        }

        public string Text { get; set; }

        public string PublicId { get; set; }

        public string FontFamily { get; set; }

        public int FontSize { get; set; }

        public string FontColor { get; set; }

        [Obsolete("Property FontWeitgh is deprecated, please use FontWeight instead")]
        public string FontWeitgh
        {
            get { return FontWeight; }
            set { FontWeight = value; }
        }

        public string FontWeight { get; set; }

        public string FontStyle { get; set; }

        public string Background { get; set; }

        public string Opacity { get; set; }

        public string TextDecoration { get; set; }

        public string TextAlign { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Text))
                throw new ArgumentException("Text must be specified in TextParams!");
        }

        public override SortedDictionary<string, object> ToParamsDictionary()
        {
            var paramsDictionary = base.ToParamsDictionary();
            AddParam(paramsDictionary, "text", Text);
            AddParam(paramsDictionary, "public_id", PublicId);
            AddParam(paramsDictionary, "font_family", FontFamily);
            AddParam(paramsDictionary, "font_size", FontSize.ToString());
            AddParam(paramsDictionary, "font_color", FontColor);
            AddParam(paramsDictionary, "font_weight", FontWeight);
            AddParam(paramsDictionary, "font_style", FontStyle);
            AddParam(paramsDictionary, "background", Background);
            AddParam(paramsDictionary, "opacity", Opacity);
            AddParam(paramsDictionary, "text_decoration", TextDecoration);
            AddParam(paramsDictionary, "text_align", TextAlign);
            return paramsDictionary;
        }
    }
}