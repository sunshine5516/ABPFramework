using Abp.Dependency;

namespace Abp.Domain.Services
{
    /// <summary>
    /// 所有域服务必须实现此接口，以按照约定标识它们。
    /// </summary>
    public interface IDomainService : ITransientDependency
    {

    }
}