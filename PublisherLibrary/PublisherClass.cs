using EventLibrary;

namespace PublisherLibrary
{
    public class PublisherClass
    {
        private readonly EventManager eventManager;

        public PublisherClass() { eventManager = EventManager.GetInstance(); }

        public void DoWork()
        {
            eventManager.Fire(new SomeConcreteEvent
            {
                Param = "Event fired from PublisherClass::DoWork"
            });
        }

        public void DoAnotherWork(int i)
        {
            eventManager.Fire(new AnotherConcreteEvent
            {
                Param = $"Event fired from PublisherClass::DoAnotherWork {i}"
            });
        }
    }
}