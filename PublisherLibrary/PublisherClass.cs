using EventLibrary;

namespace PublisherLibrary
{
    public class PublisherClass
    {
        private readonly EventManager eventManager;

        public PublisherClass() { eventManager = EventManager.Instance; }

        public void DoWork()
        {
            eventManager.Fire(new SomeConcreteEvent
            {
                Param = "Event fired from PublisherClass::DoWork"
            });
        }

        public void DoAnotherWork()
        {
            eventManager.Fire(new AnotherConcreteEvent
            {
                Param = $"Event fired from PublisherClass::DoAnotherWork"
            });
        }
    }
}