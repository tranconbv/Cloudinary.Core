﻿// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.BaseParams
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CloudinaryDotNet.Actions
{
    public abstract class BaseParams
    {
        private readonly SortedDictionary<string, object> CustomParams = new SortedDictionary<string, object>();

        public abstract void Check();

        public virtual SortedDictionary<string, object> ToParamsDictionary()
        {
            return new SortedDictionary<string, object>(CustomParams);
        }

        public void AddCustomParam(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            CustomParams.Add(key, value);
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            dict.Add(key, value);
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, DateTime value)
        {
            if (!(value != DateTime.MinValue))
                return;
            dict.Add(key, value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, float value)
        {
            dict.Add(key, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, IEnumerable<string> value)
        {
            if (value == null)
                return;
            dict.Add(key, value);
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, bool value)
        {
            dict.Add(key, value ? "true" : "false");
        }

        protected void AddParam(SortedDictionary<string, object> dict, string key, bool? value)
        {
            if (!value.HasValue)
                return;
            AddParam(dict, key, value.Value);
        }

        protected void AddCoordinates(SortedDictionary<string, object> dict, string key, object coordObj)
        {
            if (coordObj == null)
                return;
            if (coordObj is Rectangle)
            {
                var rectangle = (Rectangle) coordObj;
                dict.Add(key, string.Format("{0},{1},{2},{3}", (object) rectangle.X, (object) rectangle.Y, (object) rectangle.Width, (object) rectangle.Height));
            }
            else if (coordObj is List<Rectangle>)
            {
                var source = (List<Rectangle>) coordObj;
                dict.Add(key, string.Join("|", source.Select(r => string.Format("{0},{1},{2},{3}", (object) r.X, (object) r.Y, (object) r.Width, (object) r.Height)).ToArray()));
            }
            else
            {
                dict.Add(key, coordObj.ToString());
            }
        }
    }
}