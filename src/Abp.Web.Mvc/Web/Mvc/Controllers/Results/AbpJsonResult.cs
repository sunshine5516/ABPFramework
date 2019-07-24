using System;
using System.Web.Mvc;
using Abp.Json;
using Newtonsoft.Json;

/* This class is inspired from http://www.matskarlsson.se/blog/serialize-net-objects-as-camelcase-json */

namespace Abp.Web.Mvc.Controllers.Results
{
    /// <summary>
    /// 重写MVC controllers的JsonResult.
    /// </summary>
    public class AbpJsonResult : JsonResult
    {
        /// <summary>
        /// 指示此JSON结果是否基于序列化。
        /// Default: true.
        /// </summary>
        public bool CamelCase { get; set; }

        /// <summary>
        /// 是否在序列化中使用缩进
        /// Default: false.
        /// </summary>
        public bool Indented { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AbpJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            CamelCase = true;
        }

        /// <summary>
        /// Constructor with JSON data.
        /// </summary>
        /// <param name="data">JSON data</param>
        public AbpJsonResult(object data)
            : this()
        {
            Data = data;
        }

        /// <inheritdoc/>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var ignoreJsonRequestBehaviorDenyGet = false;
            if (context.HttpContext.Items.Contains("IgnoreJsonRequestBehaviorDenyGet"))
            {
                ignoreJsonRequestBehaviorDenyGet = String.Equals(context.HttpContext.Items["IgnoreJsonRequestBehaviorDenyGet"].ToString(), "true", StringComparison.OrdinalIgnoreCase);
            }

            if (!ignoreJsonRequestBehaviorDenyGet && JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(Data.ToJsonString(CamelCase, Indented));
            }
        }
    }
}