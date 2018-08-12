using System;
using EventLibrary;

namespace SubscriberLibrary
{
    public class SubscriberClass
    {
        private readonly EventManager eventManager;
        private readonly Action<IEventBase> anotherConcreteEventCallback;

        public SubscriberClass()
        {
            eventManager = EventManager.Instance;

            eventManager.Subscribe<SomeConcreteEvent>(o =>
                Console.WriteLine($"SomeConcreteEvent handled in SubscriberClass: {((SomeConcreteEvent)o).Param}"));

            anotherConcreteEventCallback =
                eventManager.Subscribe<AnotherConcreteEvent>(o => HandleAnotherConcreteEvent((AnotherConcreteEvent)o));
        }

        private void HandleAnotherConcreteEvent(AnotherConcreteEvent anotherConcreteEvent)
        {
            eventManager.UnSubscribe<AnotherConcreteEvent>(anotherConcreteEventCallback);

            Console.WriteLine($"AnotherConcreteEvent handled in SubscriberClass: {anotherConcreteEvent.Param}");
        }
    }
}