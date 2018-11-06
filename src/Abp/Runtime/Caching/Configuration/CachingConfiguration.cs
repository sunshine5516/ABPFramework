using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Configuration.Startup;

namespace Abp.Runtime.Caching.Configuration
{
    internal class CachingConfiguration : ICachingConfiguration
    {
        #region ����ʵ��
        public IAbpStartupConfiguration AbpConfiguration { get; private set; }

        public IReadOnlyList<ICacheConfigurator> Configurators
        {
            get { return _configurators.ToImmutableList(); }
        }
        private readonly List<ICacheConfigurator> _configurators;
        #endregion
        #region ���캯��
        public CachingConfiguration(IAbpStartupConfiguration abpConfiguration)
        {
            AbpConfiguration = abpConfiguration;

            _configurators = new List<ICacheConfigurator>();
        }
        #endregion



        public void ConfigureAll(Action<ICache> initAction)
        {
            _configurators.Add(new CacheConfigurator(initAction));
        }

        public void Configure(string cacheName, Action<ICache> initAction)
        {
            _configurators.Add(new CacheConfigurator(cacheName, initAction));
        }
    }
}