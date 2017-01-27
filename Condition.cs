// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Condition
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CloudinaryDotNet
{
    public class Condition
    {
        public static Dictionary<string, string> Operators = new Dictionary<string, string>
        {
            {
                "=",
                "eq"
            },
            {
                "!=",
                "ne"
            },
            {
                "<",
                "lt"
            },
            {
                ">",
                "gt"
            },
            {
                "<=",
                "lte"
            },
            {
                ">=",
                "gte"
            },
            {
                "&&",
                "and"
            },
            {
                "||",
                "or"
            }
        };

        public static Dictionary<string, string> Parameters = new Dictionary<string, string>
        {
            {
                "width",
                "w"
            },
            {
                "height",
                "h"
            },
            {
                "aspect_ratio",
                "ar"
            },
            {
                "aspectRatio",
                "ar"
            },
            {
                "page_count",
                "pc"
            },
            {
                "pageCount",
                "pc"
            },
            {
                "face_count",
                "fc"
            },
            {
                "faceCount",
                "fc"
            }
        };

        protected List<string> predicateList;

        public Condition()
        {
            predicateList = new List<string>();
        }

        public Condition(string condition)
            : this()
        {
            if (string.IsNullOrEmpty(condition))
                return;
            predicateList.Add(Literal(condition));
        }

        public Transformation Parent { get; private set; }

        private string Literal(string condition)
        {
            condition = Regex.Replace(condition, "[ _]+", "_");
            var pattern = string.Format("({0}|[=<>&|!]+)", string.Join("|", Parameters.Keys.ToArray()));
            return Regex.Replace(condition, pattern, m => GetOperatorReplacement(m.Value));
        }

        private string GetOperatorReplacement(string value)
        {
            if (Operators.ContainsKey(value))
                return Operators[value];
            if (Parameters.ContainsKey(value))
                return Parameters[value];
            return value;
        }

        public Condition SetParent(Transformation parent)
        {
            Parent = parent;
            return this;
        }

        public string Serialize()
        {
            return string.Join("_", predicateList.ToArray());
        }

        public override string ToString()
        {
            return Serialize();
        }

        protected Condition Predicate(string name, string @operator, string value)
        {
            if (Operators.ContainsKey(@operator))
                @operator = Operators[@operator];
            predicateList.Add(string.Format("{0}_{1}_{2}", name, @operator, value));
            return this;
        }

        public Condition And()
        {
            predicateList.Add("and");
            return this;
        }

        public Condition Or()
        {
            predicateList.Add("or");
            return this;
        }

        public Transformation Then()
        {
            Parent.IfCondition(Serialize());
            return Parent;
        }

        public Condition Width(string @operator, object value)
        {
            predicateList.Add(string.Format("w_{0}_{1}", @operator, value));
            return this;
        }

        public Condition Height(string @operator, object value)
        {
            predicateList.Add(string.Format("h_{0}_{1}", @operator, value));
            return this;
        }

        public Condition AspectRatio(string @operator, string value)
        {
            predicateList.Add(string.Format("ar_{0}_{1}", @operator, value));
            return this;
        }

        public Condition FaceCount(string @operator, object value)
        {
            predicateList.Add(string.Format("fc_{0}_{1}", @operator, value));
            return this;
        }

        public Condition PageCount(string @operator, object value)
        {
            predicateList.Add(string.Format("pc_{0}_{1}", @operator, value));
            return this;
        }
    }
}