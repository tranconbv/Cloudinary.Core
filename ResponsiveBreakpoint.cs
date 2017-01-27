// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.ResponsiveBreakpoint
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using Newtonsoft.Json.Linq;

namespace CloudinaryDotNet
{
  public class ResponsiveBreakpoint : JObject
  {
    private const string CREATE_DERIVED = "create_derived";
    private const string TRANSFORMATION = "transformation";
    private const string MAX_WIDTH = "max_width";
    private const string MIN_WIDTH = "min_width";
    private const string BYTES_STEP = "bytes_step";
    private const string MAX_IMAGES = "max_images";

    public ResponsiveBreakpoint()
    {
      this.Add("create_derived", (JToken) true);
    }

    public bool IsCreateDerived()
    {
      return this.GetValue("create_derived").Value<bool>();
    }

    public ResponsiveBreakpoint CreateDerived(bool createDerived)
    {
      this["create_derived"] = (JToken) createDerived;
      return this;
    }

    public ResponsiveBreakpoint Transformation(Transformation transformation)
    {
      this["transformation"] = (JToken) transformation.ToString();
      return this;
    }

    public int MaxWidth()
    {
      return this.Value<int>((object) "max_width");
    }

    public ResponsiveBreakpoint MaxWidth(int maxWidth)
    {
      this["max_width"] = (JToken) maxWidth;
      return this;
    }

    public int MinWidth()
    {
      return this.Value<int>((object) "min_width");
    }

    public ResponsiveBreakpoint MinWidth(int minWidth)
    {
      this["min_width"] = (JToken) minWidth;
      return this;
    }

    public int BytesStep()
    {
      return this.Value<int>((object) "bytes_step");
    }

    public ResponsiveBreakpoint BytesStep(int bytesStep)
    {
      this["bytes_step"] = (JToken) bytesStep;
      return this;
    }

    public int MaxImages()
    {
      return this.Value<int>((object) "max_images");
    }

    public ResponsiveBreakpoint MaxImages(int maxImages)
    {
      this["max_images"] = (JToken) maxImages;
      return this;
    }
  }
}
