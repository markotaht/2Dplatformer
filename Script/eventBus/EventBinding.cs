using Godot;
using System;

namespace EventBus
{
    public interface IEventBinding<T>
    {
        public Action<T> OnEvent { get; set; }
        public System.Action OnEventNoArgs { get; set; }
    }

    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        Action<T> onEvent = _ => { };
        System.Action onEventNoArgs = () => { };

        Action<T> IEventBinding<T>.OnEvent
        {
            get => onEvent;
            set => onEvent = value;
        }

        System.Action IEventBinding<T>.OnEventNoArgs
        {
            get => onEventNoArgs;
            set => onEventNoArgs = value;
        }

        public EventBinding(Action<T> onEvent) => this.onEvent = onEvent;
        public EventBinding(System.Action onEventNoArgs) => this.onEventNoArgs = onEventNoArgs;

        public void Add(System.Action onEvent) => onEventNoArgs += onEvent;
        public void Remove(System.Action onEvent) => onEventNoArgs -= onEvent;

        public void Add(Action<T> onEvent) => this.onEvent += onEvent;
        public void Remove(Action<T> onEvent) => this.onEvent -= onEvent;
    }
}
