using System.Data.Entity;
using Abp.Domain.Uow;
using Abp.MultiTenancy;

namespace Abp.EntityFramework.Uow
{
    /// <summary>
    /// �̳�<see cref="IDbContextProvider{TDbContext}"/>��active unit of work ��ȡ�����Ķ���
    /// </summary>
    /// <typeparam name="TDbContext">Type of the DbContext</typeparam>
    public class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext> 
        where TDbContext : DbContext
    {
       private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="currentUnitOfWorkProvider"></param>
        public UnitOfWorkDbContextProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }

        public TDbContext GetDbContext()
        {
            return GetDbContext(null);
        }

        public TDbContext GetDbContext(MultiTenancySides? multiTenancySide)
        {
            return _currentUnitOfWorkProvider.Current.GetDbContext<TDbContext>(multiTenancySide);
        }
    }
}