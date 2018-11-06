using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Abp.Dependency
{
    /// <summary>
    /// ֱ��ִ������ע������
    /// </summary>
    public class IocManager : IIocManager
    {
        /// <summary>
        /// ʵ��
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// IWindsorContainerע������
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        /// <summary>
        /// ����ע��ĳ���ע�Ἧ�ϡ�
        /// </summary>
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;

        static IocManager()
        {
            Instance = new IocManager();
        }
        #region ���캯��

        public IocManager()
        {
            IocContainer = new WindsorContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //Register self!
            IocContainer.Register(
                Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this)
                );
        }

        #endregion

        /// <summary>
        /// ��ӳ���ע�������ע����.
        /// </summary>
        /// <param name="registrar">dependency registrar</param>
        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        /// <summary>
        /// ע�����г���ע���������������򼯵����͡� 
        /// �μ�<see cref ="AddConventionalRegistrar"/>������
        /// </summary>
        /// <param name="assembly">Assembly to register</param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
        }

        /// <summary>
        /// ע�����г���ע���������������򼯵�����
        /// �μ�<see cref ="AddConventionalRegistrar"/>������
        /// </summary>
        /// <param name="assembly">Assembly to register</param>
        /// <param name="config">Additional configuration</param>
        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            var context = new ConventionalRegistrationContext(assembly, this, config);

            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }   

            if (config.InstallInstallers)
            {
                IocContainer.Install(FromAssembly.Instance(assembly));
            }
        }

        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <typeparam name="TType">Type of the class</typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
        }

        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <param name="type">Type of the class</param>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type), lifeStyle));
        }

        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <typeparam name="TType">Registering type</typeparam>
        /// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <param name="type">Type of the class</param>
        /// <param name="impl">The type that implements <paramref name="type"/></param>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type, impl).ImplementedBy(impl), lifeStyle));
        }

        /// <summary>
        /// ���������Ƿ�ע��
        /// </summary>
        /// <param name="type">Type to check</param>
        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        /// <summary>
        /// �����������Ƿ���֮ǰע�ᡣ
        /// </summary>
        /// <typeparam name="TType">Type to check</typeparam>
        public bool IsRegistered<TType>()
        {
            return IocContainer.Kernel.HasComponent(typeof(TType));
        }

        /// <summary>
        /// ��IOC������ȡ����
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <returns>����ʵ��</returns>
        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        /// <summary>
        /// ��IOC������ȡ����.
        /// </summary> 
        /// <typeparam name="T">Type of the object to cast</typeparam>
        /// <param name="type">Type of the object to resolve</param>
        /// <returns>����ʵ��</returns>
        public T Resolve<T>(Type type)
        {
            return (T)IocContainer.Resolve(type);
        }

        /// <summary>
        /// ��IOC������ȡ����.
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>����ʵ��</returns>
        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        /// <summary>
        /// ��IOC������ȡ����
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <returns>����ʵ��</returns>
        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }

        /// <summary>
        /// ��IOC������ȡ����.
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>����ʵ��</returns>
        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve(type, argumentsAsAnonymousType);
        }

        ///<inheritdoc/>
        public T[] ResolveAll<T>()
        {
            return IocContainer.ResolveAll<T>();
        }

        ///<inheritdoc/>
        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.ResolveAll<T>(argumentsAsAnonymousType);
        }

        ///<inheritdoc/>
        public object[] ResolveAll(Type type)
        {
            return IocContainer.ResolveAll(type).Cast<object>().ToArray();
        }

        ///<inheritdoc/>
        public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.ResolveAll(type, argumentsAsAnonymousType).Cast<object>().ToArray();
        }

        /// <summary>
        /// Releases a pre-resolved object. See Resolve methods.
        /// </summary>
        /// <param name="obj">Object to be released</param>
        public void Release(object obj)
        {
            IocContainer.Release(obj);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }
    }
}