// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.ArchiveResult
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Net;

namespace CloudinaryDotNet.Actions
{
  public class ArchiveResult : BaseResult
  {
    public string Url { get; private set; }

    public string SecureUrl { get; private set; }

    public string PublicId { get; private set; }

    public long Bytes { get; private set; }

    public int FileCount { get; private set; }

    internal static ArchiveResult Parse(HttpWebResponse response)
    {
      ArchiveResult archiveResult = BaseResult.Parse<ArchiveResult>(response);
      archiveResult.Url = archiveResult.JsonObj.Value<string>((object) "url");
      archiveResult.SecureUrl = archiveResult.JsonObj.Value<string>((object) "secure_url");
      archiveResult.PublicId = archiveResult.JsonObj.Value<string>((object) "public_id");
      archiveResult.Bytes = archiveResult.JsonObj.Value<long>((object) "bytes");
      archiveResult.FileCount = archiveResult.JsonObj.Value<int>((object) "file_count");
      return archiveResult;
    }
  }
}
