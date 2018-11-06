using System.Collections.Generic;
using Abp.Application.Services;

namespace Abp.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// �������ж�̬���ɵ�ApiController�Ļ���
    /// </summary>
    /// <typeparam name="T">������������</typeparam>
    /// <remarks>
    /// ��̬ApiController���ڽ�����ͨ��ΪApplication Service�ࣩ͸������ʾ��Զ�̿ͻ��ˡ�
    /// </remarks>
    public class DynamicApiController<T> : AbpApiController, IDynamicApiController, IAvoidDuplicateCrossCuttingConcerns
    {
        public List<string> AppliedCrossCuttingConcerns { get; }

        public DynamicApiController()
        {
            AppliedCrossCuttingConcerns = new List<string>();
        }
    }
}