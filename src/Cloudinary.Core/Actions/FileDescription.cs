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
        internal int BytesSent;
        internal bool EOF;

        public FileDescription(string name, Stream stream)
        {
            FileName = name;
            Stream = stream;
        }

        public FileDescription(string filePath)
        {
            IsRemote = Regex.IsMatch(filePath, "^ftp:.*|https?:.*|s3:.*|data:[^;]*;base64,([a-zA-Z0-9/+\n=]+)");
            FilePath = filePath;
            if (!IsRemote)
                FileName = Path.GetFileName(FilePath);
            else
                FileName = FilePath;
        }

        public Stream Stream { get; }

        public string FileName { get; }

        public string FilePath { get; }

        public bool IsRemote { get; }

        internal long GetFileLength()
        {
            return Stream == null ? new FileInfo(FilePath).Length : Stream.Length;
        }

        internal bool IsLastPart()
        {
            return GetFileLength() - BytesSent <= BufferLength;
        }
    }
}