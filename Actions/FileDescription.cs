// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.FileDescription
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.IO;
using System.Text.RegularExpressions;

namespace CloudinaryDotNet.Actions
{
  public class FileDescription
  {
    internal int BufferLength = int.MaxValue;
    private string m_name;
    private string m_path;
    private Stream m_stream;
    private bool m_isRemote;
    internal bool EOF;
    internal int BytesSent;

    public Stream Stream
    {
      get
      {
        return this.m_stream;
      }
    }

    public string FileName
    {
      get
      {
        return this.m_name;
      }
    }

    public string FilePath
    {
      get
      {
        return this.m_path;
      }
    }

    public bool IsRemote
    {
      get
      {
        return this.m_isRemote;
      }
    }

    public FileDescription(string name, Stream stream)
    {
      this.m_name = name;
      this.m_stream = stream;
    }

    public FileDescription(string filePath)
    {
      this.m_isRemote = Regex.IsMatch(filePath, "^ftp:.*|https?:.*|s3:.*|data:[^;]*;base64,([a-zA-Z0-9/+\n=]+)");
      this.m_path = filePath;
      if (!this.m_isRemote)
        this.m_name = Path.GetFileName(this.m_path);
      else
        this.m_name = this.m_path;
    }

    internal long GetFileLength()
    {
      return this.m_stream == null ? new FileInfo(this.m_path).Length : this.m_stream.Length;
    }

    internal bool IsLastPart()
    {
      return this.GetFileLength() - (long) this.BytesSent <= (long) this.BufferLength;
    }
  }
}
