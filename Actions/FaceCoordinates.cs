// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.FaceCoordinates
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CloudinaryDotNet.Actions
{
  [Obsolete("One could use List<Rectangle>")]
  public class FaceCoordinates : List<Rectangle>
  {
    public override string ToString()
    {
      return string.Join("|", this.Select<Rectangle, string>((Func<Rectangle, string>) (r => string.Format("{0},{1},{2},{3}", (object) r.X, (object) r.Y, (object) r.Width, (object) r.Height))).ToArray<string>());
    }
  }
}
