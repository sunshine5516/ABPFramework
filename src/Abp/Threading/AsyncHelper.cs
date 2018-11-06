using System;
using System.Reflection;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Abp.Threading
{
    /// <summary>
    /// 异步方法帮助类
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// 是否是异步方法
        /// </summary>
        /// <param name="method">A method to check</param>
        public static bool IsAsync(this MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.GetTypeInfo().IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
        }

        /// <summary>
        /// 是否是异步方法.
        /// </summary>
        /// <param name="method">A method to check</param>
        [Obsolete("Use MethodInfo.IsAsync() extension method!")]
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return method.IsAsync();
        }

        /// <summary>
        /// Runs a async method synchronously.
        /// </summary>
        /// <param name="func">A function that returns a result</param>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <returns>Result of the async operation</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return AsyncContext.Run(func);
        }

        /// <summary>
        /// Runs a async method synchronously.
        /// </summary>
        /// <param name="action">An async action</param>
        public static void RunSync(Func<Task> action)
        {
            AsyncContext.Run(action);
        }
    }
}
