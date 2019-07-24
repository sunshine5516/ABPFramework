using System.Net.Http;
using System.Net.Http.Headers;
using Abp.Auditing;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Abp.WebApi.Controllers.Dynamic.Formatters;

namespace Abp.WebApi.Controllers.Dynamic.Scripting
{
    /// <summary>
    /// 此类用于创建代理以从Javascript客户端调用动态api方法。
    /// </summary>
    [DontWrapResult]
    [DisableAuditing]
    [DisableAbpAntiForgeryTokenValidation]
    public class AbpServiceProxiesController : AbpApiController
    {
        private readonly ScriptProxyManager _scriptProxyManager;

        public AbpServiceProxiesController(ScriptProxyManager scriptProxyManager)
        {
            _scriptProxyManager = scriptProxyManager;
        }

        /// <summary>
        /// 获取给定服务名称的javascript代理。
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <param name="type">Script type</param>
        public HttpResponseMessage Get(string name, ProxyScriptType type = ProxyScriptType.JQuery)
        {
            var script = _scriptProxyManager.GetScript(name, type);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, script, new PlainTextFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-javascript");
            return response;
        }

        /// <summary>
        /// 获取所有服务的javascript代理。
        /// </summary>
        /// <param name="type">Script type</param>
        public HttpResponseMessage GetAll(ProxyScriptType type = ProxyScriptType.JQuery)
        {
            var script = _scriptProxyManager.GetAllScript(type);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, script, new PlainTextFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-javascript");
            return response;
        }
    }
}