using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpDemo.Application.Users
{
    public interface ITestService : IApplicationService
    {
        void GettestMethod();
        void Test();
        string GetAll();
    }
}
