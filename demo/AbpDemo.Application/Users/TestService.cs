using Abp;
using Abp.BackgroundJobs;
using Abp.Dapper.Repositories;
using Abp.Notifications;
using AbpDemo.Application.Tasks;
using AbpDemo.Tasks;

namespace AbpDemo.Application.Users
{
    public class TestService : ITestService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IDapperRepository<TaskModel> _dapperRepository;
        private readonly INotificationPublisher _notificationPublisher;
        public TestService(IBackgroundJobManager backgroundJobManager,
            IDapperRepository<TaskModel> dapperRepository,
            INotificationPublisher notificationPublisher)
        {
            this._backgroundJobManager = backgroundJobManager;
            this._notificationPublisher = notificationPublisher;
            this._dapperRepository = dapperRepository;
        }

        public string GetAll()
        {
            return "Hello ABP";
        }

        public void GettestMethod()
        {
            
        }
        public void Test()
        {
            UserIdentifier userIdentifier = new UserIdentifier(0, 35);
            _notificationPublisher.PublishAsync("NewTask", new NotificationData(), null,
        NotificationSeverity.Info, new[] { userIdentifier });
            _backgroundJobManager.EnqueueAsync<TestJob, int>(42);
            var people = _dapperRepository.Query("select * from AbpUsers");
        }
    }
}
