using Abp.Events.Bus.Handlers;

namespace Abp.Events.Bus.Factories
{
    /// <summary>
    /// Ϊ���𴴽�/��ȡ���ͷ��¼��������Ĺ�������ӿڡ�
    /// </summary>
    public interface IEventHandlerFactory
    {
        /// <summary>
        /// ��ȡһ���¼�������.
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