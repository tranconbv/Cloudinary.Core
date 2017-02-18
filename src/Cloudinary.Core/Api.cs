// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Api
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace CloudinaryDotNet
{
    public class Api : ISignProvider
    {
        public const string ADDR_API = "api.cloudinary.com";
        public const string ADDR_RES = "res.cloudinary.com";
        public const string API_VERSION = "v1_1";
        public const string HTTP_BOUNDARY = "notrandomsequencetouseasboundary";
        public static readonly string USER_AGENT;
        public int ChunkSize = 65000;
        public bool CSubDomain;
        public string PrivateCdn;
        //public Func<string, HttpWebRequest> RequestBuilder = x => WebRequest.Create(x) as HttpWebRequest;
        public bool ShortenUrl;
        public string Suffix;
        public int Timeout;
        public bool UseChunkedEncoding = true;
        public bool UsePrivateCdn;
        public bool UseRootPath;
        public string UserPlatform;

        static Api()
        {
            var version = typeof(Api).GetTypeInfo().Assembly.GetName().Version;
            USER_AGENT = string.Format("CloudinaryDotNet/{0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

        public Api()
            : this(Environment.GetEnvironmentVariable("CLOUDINARY_URL"))
        {
        }

        public Api(string cloudinaryUrl)
        {
            if (string.IsNullOrEmpty(cloudinaryUrl))
                throw new ArgumentException("Valid cloudinary init string must be provided!");
            var uri = new Uri(cloudinaryUrl);
            if (string.IsNullOrEmpty(uri.Host))
                throw new ArgumentException("Cloud name must be specified as host name in URL!");
            var strArray = uri.UserInfo.Split(':');
            Account = new Account(uri.Host, strArray[0], strArray[1]);
            UsePrivateCdn = !string.IsNullOrEmpty(uri.AbsolutePath) && uri.AbsolutePath != "/";
            PrivateCdn = string.Empty;
            if (!UsePrivateCdn)
                return;
            PrivateCdn = uri.AbsolutePath;
        }

        public Api(Account account, bool usePrivateCdn, string privateCdn, bool shortenUrl, bool cSubDomain)
            : this(account)
        {
            UsePrivateCdn = usePrivateCdn;
            PrivateCdn = privateCdn;
            ShortenUrl = shortenUrl;
            CSubDomain = cSubDomain;
        }

        public Api(Account account)
        {
            if (account == null)
                throw new ArgumentException("Account can't be null!");
            if (string.IsNullOrEmpty(account.Cloud))
                throw new ArgumentException("Cloud name must be specified in Account!");
            UsePrivateCdn = false;
            Account = account;
        }

        public Account Account { get; }

        public string ApiBaseAddress { get; set; } = "https://api.cloudinary.com";

        public Url Url => new Url(Account.Cloud, this).CSubDomain(CSubDomain).Shorten(ShortenUrl).PrivateCdn(UsePrivateCdn).Secure(UsePrivateCdn).SecureDistribution(PrivateCdn);

        public Url UrlImgUp => Url.ResourceType("image").Action("upload").UseRootPath(UseRootPath).Suffix(Suffix);

        public Url UrlVideoUp => Url.ResourceType("video").Action("upload").UseRootPath(UseRootPath).Suffix(Suffix);

        public Url ApiUrl => Url.CloudinaryAddr(ApiBaseAddress);

        public Url ApiUrlImgUp => ApiUrl.Action("upload").ResourceType("image");

        public Url ApiUrlV => ApiUrl.ApiVersion("v1_1");

        public Url ApiUrlImgUpV => ApiUrlV.Action("upload").ResourceType("image");

        public Url ApiUrlVideoUpV => ApiUrlV.Action("upload").ResourceType("video");

        public string SignParameters(IDictionary<string, object> parameters)
        {
            var stringBuilder1 =
                new StringBuilder(string.Join("&",
                    parameters.Where(pair => pair.Value != null)
                        .Select(pair => string.Format("{0}={1}", pair.Key, pair.Value is IEnumerable<string> ? string.Join(",", ((IEnumerable<string>)pair.Value).ToArray()) : pair.Value.ToString()))
                        .ToArray()));
            stringBuilder1.Append(Account.ApiSecret);
            var hash = ComputeHash(stringBuilder1.ToString());
            var stringBuilder2 = new StringBuilder();
            foreach (var num in hash)
                stringBuilder2.Append(num.ToString("x2"));
            return stringBuilder2.ToString();
        }

        public string SignUriPart(string uriPart)
        {
            return "s--" + Convert.ToBase64String(ComputeHash(uriPart + Account.ApiSecret)).Substring(0, 8).Replace("+", "-").Replace("/", "_") + "--/";
        }

        public static string GetCloudinaryParam<T>(T e)
        {
            var customAttributes = (DescriptionAttribute[])typeof(T).GetTypeInfo().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (customAttributes.Length == 0)
                throw new ArgumentException("Enum fields must be decorated with DescriptionAttribute!");
            return customAttributes[0].Description;
        }

        public static T ParseCloudinaryParam<T>(string s)
        {
            foreach (var field in typeof(T).GetTypeInfo().GetFields())
            {
                var customAttributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (customAttributes.Length != 0 && s == customAttributes[0].Description)
                    return (T)field.GetValue(null);
            }
            return default(T);
        }

        public async Task<HttpResponseMessage> CallAsync(HttpMethod method, string url, SortedDictionary<string, object> parameters, FileDescription file, Dictionary<string, string> extraHeaders = null)
        {
            using (var stream = new MemoryStream())
            {
                var bytes = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Account.ApiKey, Account.ApiSecret));
                using (var client = new HttpClient()
                {
                    DefaultRequestHeaders =
                    {
                        { "User-Agent", string.IsNullOrEmpty(UserPlatform) ? USER_AGENT : string.Format("{0} {1}", UserPlatform, USER_AGENT) },
                        {"Authorization",  string.Format("Basic {0}", Convert.ToBase64String(bytes))}
                    }
                })
                {
                    if (this.Timeout > 0)
                        client.Timeout = TimeSpan.FromMilliseconds(this.Timeout);

                    var content = new StreamContent(stream) { };

                    if (extraHeaders != null)
                        foreach (var extraHeader in extraHeaders)
                            content.Headers.Add(extraHeader.Key, extraHeader.Value);



                    if (parameters != null && (method == HttpMethod.Post || method == HttpMethod.Put))
                    {
                        content.Headers.Add("Content-Type", "multipart/form-data; boundary=notrandomsequencetouseasboundary");
                        if (!parameters.ContainsKey("unsigned") || parameters["unsigned"].ToString() == "false")
                            FinalizeUploadParameters(parameters);

                        var writer = new StreamWriter(stream);
                        foreach (var parameter in parameters)
                            if (parameter.Value != null)
                                if (parameter.Value is IEnumerable<string>)
                                    foreach (var str in (IEnumerable<string>)parameter.Value)
                                        WriteParam(writer, parameter.Key + "[]", str);
                                else
                                    WriteParam(writer, parameter.Key, parameter.Value.ToString());
                        if (file != null)
                            WriteFile(writer, file);
                        writer.Write("--{0}--", HTTP_BOUNDARY);

                        writer.Flush();
                        stream.Position = 0;

                    }
                    return await client.SendAsync(new HttpRequestMessage(method, url) { Content = content });
                }

            }
        }


        public string GetUploadUrl(string resourceType = "auto")
        {
            return ApiUrlV.Action("upload").ResourceType(resourceType).BuildUrl();
        }





        private byte[] ComputeHash(string s)
        {
            using (var shA1 = SHA1.Create())
            {
                return shA1.ComputeHash(Encoding.UTF8.GetBytes(s));
            }
        }

        private string GetTime()
        {
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        }

        public void FinalizeUploadParameters(IDictionary<string, object> parameters)
        {
            parameters.Add("timestamp", GetTime());
            parameters.Add("signature", SignParameters(parameters));
            parameters.Add("api_key", Account.ApiKey);
        }

        private void WriteParam(StreamWriter writer, string key, string value)
        {
            WriteLine(writer, "--{0}", HTTP_BOUNDARY);
            WriteLine(writer, "Content-Disposition: form-data; name=\"{0}\"", key);
            WriteLine(writer);
            WriteLine(writer, value);
        }

        private void WriteFile(StreamWriter writer, FileDescription file)
        { //todo add rather concat streams than write into new stream.
            if (file.IsRemote)
            {
                WriteParam(writer, "file", file.FilePath);
            }
            else
            {
                var bytesSent = 0;
                if (file.Stream == null)
                {
                    using (var fileStream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        fileStream.Seek(file.BytesSent, SeekOrigin.Begin);
                        file.EOF = WriteFile(writer, fileStream, file.BufferLength, file.FileName, out bytesSent);
                        file.BytesSent += bytesSent;
                    }
                }
                else
                {
                    file.EOF = WriteFile(writer, file.Stream, file.BufferLength, file.FileName, out bytesSent);
                    file.BytesSent += bytesSent;
                }
            }
        }

        private bool WriteFile(StreamWriter writer, Stream stream, int length, string fileName, out int bytesSent)
        {
            WriteLine(writer, "--{0}", HTTP_BOUNDARY);
            WriteLine(writer, "Content-Disposition: form-data;  name=\"file\"; filename=\"{0}\"", fileName);
            WriteLine(writer, "Content-Type: application/octet-stream");
            WriteLine(writer);
            writer.Flush();
            bytesSent = 0;
            var buffer1 = new byte[ChunkSize];
            var count1 = 0;
            int num;
            while ((num = length - bytesSent) > 0)
            {
                var stream1 = stream;
                var buffer2 = buffer1;
                var offset = 0;
                var count2 = num > buffer1.Length ? buffer1.Length : num;
                if ((count1 = stream1.Read(buffer2, offset, count2)) > 0)
                {
                    writer.BaseStream.Write(buffer1, 0, count1);
                    bytesSent += count1;
                }
                else
                {
                    break;
                }
            }
            return count1 == 0;
        }

        private void WriteLine(StreamWriter writer)
        {
            writer.Write("\r\n");
        }

        private void WriteLine(StreamWriter writer, string format)
        {
            writer.Write(format);
            writer.Write("\r\n");
        }

        private void WriteLine(StreamWriter writer, string format, object val)
        {
            writer.Write(format, val);
            writer.Write("\r\n");
        }


    }
}