using System;
using Abp.Events.Bus.Handlers;

namespace Abp.Events.Bus.Factories.Internals
{
    /// <summary>
    /// 该工厂每次都会创建一个新的EventHandler的实例。
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal class TransientEventHandlerFactory<THandler> : IEventHandlerFactory 
        where THandler : IEventHandler, new()
    {
        /// <summary>
        /// 返回一个处理器对象实例.
        /// </summary>
        /// <returns>The handler object</returns>
        public IEventHandler GetHandler()
        {
            return new THandler();
        }

        /// <summary>
        /// Disposes the handler object if it's <see cref="IDisposable"/>. Does nothing if it's not.
        /// </summary>
        /// <param name="handler">Handler to be released</param>
        public void ReleaseHandler(IEventHandler handler)
        {
            if (handler is IDisposable)
            {
                (handler as IDisposable).Dispose();
            }
        }
    }
}