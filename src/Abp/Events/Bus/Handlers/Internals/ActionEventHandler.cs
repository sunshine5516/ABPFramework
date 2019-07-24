using System;
using Abp.Dependency;

namespace Abp.Events.Bus.Handlers.Internals
{
    /// <summary>
    /// �������������ã���һ��Action�����һ���¼�������EventHandler
    /// </summary>
    /// <typeparam name="TEventData">Event type</typeparam>
    internal class ActionEventHandler<TEventData> :
        IEventHandler<TEventData>,
        ITransientDependency
    {
        /// <summary>
        /// �����¼��Ķ���.
        /// </summary>
        public Action<TEventData> Action { get; private set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="handler">Action to handle the event</param>
        public ActionEventHandler(Action<TEventData> handler)
        {
            Action = handler;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(TEventData eventData)
        {
            Action(eventData);
        }
    }
}