using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Abp.Modules
{
    /// <summary>
    /// ��װAbpModule�Ļ�����Ϣ����Ҫ����Assembly���������򼯣���
    /// Type�����ͣ���Dependencies��������ģ�飩��IsLoadedAsPlugIn���Ƿ���ģ�飩.
    /// </summary>
    public class AbpModuleInfo
    {
        /// <summary>
        /// ����ģ�鶨��ĳ���.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// ģ�������.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// ģ���ʵ��.
        /// </summary>
        public AbpModule Instance { get; }

        /// <summary>
        /// �Ƿ���Ϊ�������.
        /// </summary>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// ����ģ��.
        /// </summary>
        public List<AbpModuleInfo> Dependencies { get; }

        /// <summary>
        /// ����һ���µ�AbpModuleInfo����
        /// </summary>
        public AbpModuleInfo([NotNull] Type type, [NotNull] AbpModule instance, bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            Type = type;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;
            Assembly = Type.GetTypeInfo().Assembly;

            Dependencies = new List<AbpModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ??
                   Type.FullName;
        }
    }
}