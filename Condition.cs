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
    public static Dictionary<string, string> Operators = new Dictionary<string, string>()
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
    public static Dictionary<string, string> Parameters = new Dictionary<string, string>()
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

    public Transformation Parent { get; private set; }

    public Condition()
    {
      this.predicateList = new List<string>();
    }

    public Condition(string condition)
      : this()
    {
      if (string.IsNullOrEmpty(condition))
        return;
      this.predicateList.Add(this.Literal(condition));
    }

    private string Literal(string condition)
    {
      condition = Regex.Replace(condition, "[ _]+", "_");
      string pattern = string.Format("({0}|[=<>&|!]+)", (object) string.Join("|", Condition.Parameters.Keys.ToArray<string>()));
      return Regex.Replace(condition, pattern, (MatchEvaluator) (m => this.GetOperatorReplacement(m.Value)));
    }

    private string GetOperatorReplacement(string value)
    {
      if (Condition.Operators.ContainsKey(value))
        return Condition.Operators[value];
      if (Condition.Parameters.ContainsKey(value))
        return Condition.Parameters[value];
      return value;
    }

    public Condition SetParent(Transformation parent)
    {
      this.Parent = parent;
      return this;
    }

    public string Serialize()
    {
      return string.Join("_", this.predicateList.ToArray());
    }

    public override string ToString()
    {
      return this.Serialize();
    }

    protected Condition Predicate(string name, string @operator, string value)
    {
      if (Condition.Operators.ContainsKey(@operator))
        @operator = Condition.Operators[@operator];
      this.predicateList.Add(string.Format("{0}_{1}_{2}", (object) name, (object) @operator, (object) value));
      return this;
    }

    public Condition And()
    {
      this.predicateList.Add("and");
      return this;
    }

    public Condition Or()
    {
      this.predicateList.Add("or");
      return this;
    }

    public Transformation Then()
    {
      this.Parent.IfCondition(this.Serialize());
      return this.Parent;
    }

    public Condition Width(string @operator, object value)
    {
      this.predicateList.Add(string.Format("w_{0}_{1}", (object) @operator, value));
      return this;
    }

    public Condition Height(string @operator, object value)
    {
      this.predicateList.Add(string.Format("h_{0}_{1}", (object) @operator, value));
      return this;
    }

    public Condition AspectRatio(string @operator, string value)
    {
      this.predicateList.Add(string.Format("ar_{0}_{1}", (object) @operator, (object) value));
      return this;
    }

    public Condition FaceCount(string @operator, object value)
    {
      this.predicateList.Add(string.Format("fc_{0}_{1}", (object) @operator, value));
      return this;
    }

    public Condition PageCount(string @operator, object value)
    {
      this.predicateList.Add(string.Format("pc_{0}_{1}", (object) @operator, value));
      return this;
    }
  }
}
