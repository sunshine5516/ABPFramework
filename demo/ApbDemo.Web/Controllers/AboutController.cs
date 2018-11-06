using System.Web.Mvc;

namespace AbpDemo.Web.Controllers
{
    public class AboutController : ABPFrameworkDemoControllerBase
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
	}
}