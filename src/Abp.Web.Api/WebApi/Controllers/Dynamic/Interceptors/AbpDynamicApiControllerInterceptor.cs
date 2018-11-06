using System.Reflection;
using Abp.Extensions;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Castle.DynamicProxy;

namespace Abp.WebApi.Controllers.Dynamic.Interceptors
{
    /// <summary>
    /// ʵ����Castle��IInterceptor����Ϊ��̬���ɵ�DynamicApiController<T>����������
    /// ���������ж�action�ĵ��ã�Ȼ��ͨ��������õײ���ʵ��IApplicationService����ķ�����
    /// ��������̬������.
    /// ������Զ�̬���ɵ�api�������ķ������� �Լ����õײ�������
    /// </summary>
    /// <typeparam name="T">Type of the proxied object</typeparam>
    public class AbpDynamicApiControllerInterceptor<T> : IInterceptor
    {
        /// <summary>
        /// ʵ�ʶ���ʵ���ڵ��ö�̬�������ķ���ʱ�������ķ�����
        /// </summary>
        private readonly T _proxiedObject;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="proxiedObject">Real object instance to call it's methods when dynamic controller's methods are called</param>
        public AbpDynamicApiControllerInterceptor(T proxiedObject)
        {
            _proxiedObject = proxiedObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation">����������Ϣ</param>
        public void Intercept(IInvocation invocation)
        {
            //If method call is for generic type (T)...
            if (DynamicApiControllerActionHelper.IsMethodOfType(invocation.Method, typeof(T)))
            {
                //Call real object's method
                try
                {
                    invocation.ReturnValue = invocation.Method.Invoke(_proxiedObject, invocation.Arguments);
                }
                catch (TargetInvocationException targetInvocation)
                {
                    if (targetInvocation.InnerException != null)
                    {
                        targetInvocation.InnerException.ReThrow();
                    }

                    throw;
                }
            }
            else
            {
                //Call api controller's methods as usual.
                invocation.Proceed();
            }
        }
    }
}