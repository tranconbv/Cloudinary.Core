using System.Text;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;

namespace CloudinaryDotNet
{
    public static class HtmlCloudinaryExtensions
    {


        public static IHtmlContent GetCloudinaryJsConfig(this Cloudinary cloudinary, bool directUpload = false, string dir = "")
        {
            if (string.IsNullOrEmpty(dir))
                dir = "/Scripts";
            var sb = new StringBuilder(1000);
            AppendScriptLine(sb, dir, "jquery.ui.widget.js");
            AppendScriptLine(sb, dir, "jquery.iframe-transport.js");
            AppendScriptLine(sb, dir, "jquery.fileupload.js");
            AppendScriptLine(sb, dir, "jquery.cloudinary.js");
            if (directUpload)
            {
                AppendScriptLine(sb, dir, "canvas-to-blob.min.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-image.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-process.js");
                AppendScriptLine(sb, dir, "jquery.fileupload-validate.js");
                AppendScriptLine(sb, dir, "load-image.min.js");
            }
            var jobject = new JObject(new JProperty("cloud_name", cloudinary.Api.Account.Cloud), new JProperty("api_key", cloudinary.Api.Account.ApiKey), new JProperty("private_cdn", cloudinary.Api.UsePrivateCdn),
                new JProperty("cdn_subdomain", cloudinary.Api.CSubDomain));
            if (!string.IsNullOrEmpty(cloudinary.Api.PrivateCdn))
                jobject.Add("secure_distribution", cloudinary.Api.PrivateCdn);
            sb.AppendLine("<script type='text/javascript'>");
            sb.Append("$.cloudinary.config(");
            sb.Append(jobject);
            sb.AppendLine(");");
            sb.AppendLine("</script>");
            return new HtmlString(sb.ToString());
        }

        private static void AppendScriptLine(StringBuilder sb, string dir, string script)
        {
            sb.Append("<script src=\"");
            sb.Append(dir);
            if (!dir.EndsWith("/") && !dir.EndsWith("\\"))
                sb.Append("/");
            sb.Append(script);
            sb.AppendLine("\"></script>");
        }

    }
}