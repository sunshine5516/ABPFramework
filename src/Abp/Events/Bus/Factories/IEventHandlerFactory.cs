using Abp.Events.Bus.Handlers;

namespace Abp.Events.Bus.Factories
{
    /// <summary>
    /// 为负责创建/获取和释放事件处理程序的工厂定义接口。
    /// </summary>
    public interface IEventHandlerFactory
    {
        /// <summary>
        /// 获取一个事件处理器.
        /// </summary>
        /// <returns>The event handler</returns>
        IEventHandler GetHandler();

        /// <summary>
        /// Releases an event handler.
        /// </summary>
        /// <param name="handler">Handle to be released</param>
        void ReleaseHandler(IEventHandler handler);
    }
}