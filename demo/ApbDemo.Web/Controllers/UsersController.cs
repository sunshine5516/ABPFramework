using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Runtime.Caching;
using Abp.Web.Mvc.Authorization;
using AbpDemo.Application.Users;
using AbpDemo.Authorization;
using AbpDemo.Authorization.Roles;
using AbpDemo.Users;
using AbpDemo.Web.Models.Users;
namespace AbpDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ABPFrameworkDemoControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;
        private readonly ITestService _testService;
        private readonly ICacheManager _cacheManager;

        public UsersController(IUserAppService userAppService, 
            RoleManager roleManager, ITestService testService,
            ICacheManager cacheManager)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
            this._testService = testService;
            this._cacheManager = cacheManager;
        }

        public async Task<ActionResult> Index()
        {
            var temp = _cacheManager.GetCache("hello");
            _cacheManager.GetAllCaches();
            _testService.GettestMethod();
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };

            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}