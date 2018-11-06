using Abp.Web.Mvc.Authorization;
using System.Web.Mvc;

namespace AbpDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ABPFrameworkDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}