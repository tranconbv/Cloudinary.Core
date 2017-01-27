// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.EagerTransformation
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet
{
  public class EagerTransformation : Transformation
  {
    public string Format { get; set; }

    public EagerTransformation(params Transformation[] transforms)
      : base(((IEnumerable<Transformation>) transforms).ToList<Transformation>())
    {
    }

    public EagerTransformation(List<Transformation> transforms)
      : base(transforms)
    {
    }

    public EagerTransformation()
    {
    }

    public EagerTransformation SetFormat(string format)
    {
      this.Format = format;
      return this;
    }

    public override string Generate()
    {
      string str = base.Generate();
      if (!string.IsNullOrEmpty(this.Format))
        str = str + "/" + this.Format;
      return str;
    }
  }
}
