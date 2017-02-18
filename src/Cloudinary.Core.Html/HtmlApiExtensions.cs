using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace CloudinaryDotNet
{
    public static class HtmlApiExtensions
    {

        public static IHtmlContent BuildUnsignedUploadForm(this Api api, string field, string preset, IDictionary<string, object> parameters = null, IDictionary<string, string> htmlOptions = null)
        {
            if (parameters == null)
                parameters = new SortedDictionary<string, object>();
            parameters.Add("upload_preset", preset);
            parameters.Add("unsigned", true);
            return api.BuildUploadForm(field, "image", parameters, htmlOptions);
        }

        public static IHtmlContent BuildUploadForm(this Api api, string field, string resourceType, IDictionary<string, object> parameters = null, IDictionary<string, string> htmlOptions = null)
        {
            if (htmlOptions == null)
                htmlOptions = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(resourceType))
                resourceType = "auto";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<input type='file' name='file' data-url='")
                .Append(api.GetUploadUrl(resourceType))
                .Append("' data-form-data='")
                .Append(api.PrepareUploadParams(parameters))
                .Append("' data-cloudinary-field='")
                .Append(field)
                .Append("' class='cloudinary-fileupload");
            if (htmlOptions.ContainsKey("class"))
                stringBuilder.Append(" ").Append(htmlOptions["class"]);
            foreach (var htmlOption in htmlOptions)
                if (htmlOption.Key != "class")
                    stringBuilder.Append("' ").Append(htmlOption.Key).Append("='").Append(WebUtility.HtmlEncode(htmlOption.Value));
            stringBuilder.Append("'/>");
            return new HtmlString(stringBuilder.ToString());
        }

        public static string PrepareUploadParams(this Api api, IDictionary<string, object> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            if (!(parameters is SortedDictionary<string, object>))
                parameters = new SortedDictionary<string, object>(parameters);
            if (!parameters.ContainsKey("callback"))
                throw new ArgumentException("parameters.callback key is missing in dictioary, you can use HttpContextAccessor to get the url of this request");


            if (!parameters.ContainsKey("unsigned") || parameters["unsigned"].ToString() == "false") ;
                api.FinalizeUploadParameters(parameters);
            return JsonConvert.SerializeObject(parameters);
        }

        //unused was used for PrepareUploadParams
        public static string BuildCallbackUrl(this Api api, string path = "")
        {
            if (string.IsNullOrEmpty(path))
                path = "/Content/cloudinary_cors.html";
            if (Regex.IsMatch(path.ToLower(), "^https?:/.*"))
                return path;
            throw new NotImplementedException("Should be implemented with IHttpContextAccessor");
            //if (HttpContext.Current != null)
            //  return new Uri(HttpContext.Current.Request.Url, path).ToString();
            //throw new HttpContextNotFoundException("Http context is not set. Either use this method in the right context or provide an absolute path to file!");
        }

    }
}