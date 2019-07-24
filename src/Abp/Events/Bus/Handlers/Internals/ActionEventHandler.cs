using System;
using Abp.Dependency;

namespace Abp.Events.Bus.Handlers.Internals
{
    /// <summary>
    /// 起到适配器的作用，将一个Action适配成一个事件处理器EventHandler
    /// </summary>
    /// <typeparam name="TEventData">Event type</typeparam>
    internal class ActionEventHandler<TEventData> :
        IEventHandler<TEventData>,
        ITransientDependency
    {
        /// <summary>
        /// 处理事件的动作.
        /// </summary>
        public Action<TEventData> Action { get; private set; }

        /// <summary>
        /// 构造函数
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