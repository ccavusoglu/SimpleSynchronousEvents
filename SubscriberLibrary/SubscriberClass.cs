using System;
using EventLibrary;

namespace SubscriberLibrary
{
    public class SubscriberClass
    {
        private readonly EventManager eventManager;
        private readonly Action<IEventBase> anotherConcreteEventCallback;

        private int id;

        public SubscriberClass(int id)
        {
            this.id = id;

            eventManager = EventManager.GetInstance();

            eventManager.Subscribe<SomeConcreteEvent>(o =>
                Console.WriteLine($"SomeConcreteEvent handled in SubscriberClass {id}: {((SomeConcreteEvent)o).Param}"));

            eventManager.Subscribe<SomeConcreteEvent>(o =>
                Console.WriteLine($"SomeConcreteEvent handled in SubscriberClass1 {id}: {((SomeConcreteEvent)o).Param}"));

            anotherConcreteEventCallback =
                eventManager.Subscribe<AnotherConcreteEvent>(o => HandleAnotherConcreteEvent((AnotherConcreteEvent)o));
        }

        private void HandleAnotherConcreteEvent(AnotherConcreteEvent anotherConcreteEvent)
        {
            eventManager.UnSubscribe<AnotherConcreteEvent>(anotherConcreteEventCallback);

            Console.WriteLine($"AnotherConcreteEvent handled in SubscriberClass {id}: {anotherConcreteEvent.Param}");
        }
    }
}