using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EventLibrary
{
    public sealed class EventManager
    {
        private static EventManager InstanceSelf;
        private static readonly object InstanceLock = new object();

        private readonly ConcurrentDictionary<Type, ImmutableList<Action<IEventBase>>> subscribers;

        private EventManager()
        {
            subscribers = new ConcurrentDictionary<Type, ImmutableList<Action<IEventBase>>>();
        }

        public static EventManager Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    return InstanceSelf ?? (InstanceSelf = new EventManager());
                }
            }
        }

        public void Fire<T>(T obj) where T : IEventBase
        {
            var type = typeof(T);

            if (subscribers.TryGetValue(type, out var actions))
            {
                foreach (var action in actions)
                    action.Invoke(obj);
            }
            else
            {
                Console.WriteLine($"There isn't any subscription for event type: {type}");
            }
        }

        public Action<IEventBase> Subscribe<T>(Action<IEventBase> callback) where T : IEventBase
        {
            var type = typeof(T);

            if (!subscribers.TryGetValue(type, out var actions))
            {
                actions = ImmutableList<Action<IEventBase>>.Empty;
                subscribers.TryAdd(type, actions);
            }
            else
            {
                actions = subscribers[type];
            }

            if (!actions.Contains(callback))
                actions = actions.Add(callback);

            subscribers[type] = actions;

            return callback;
        }

        public void UnSubscribe<T>(Action<IEventBase> callback) where T : IEventBase
        {
            var type = typeof(T);

            if (!subscribers.TryGetValue(type, out var actions)) return;

            if (actions.Contains(callback))
                actions = actions.Remove(callback);

            subscribers[type] = actions;
        }
    }
}