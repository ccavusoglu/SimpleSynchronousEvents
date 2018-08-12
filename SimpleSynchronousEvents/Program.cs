using System;
using System.Threading;
using System.Threading.Tasks;
using EventLibrary;
using PublisherLibrary;
using SubscriberLibrary;

namespace SimpleSynchronousEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriber = new SubscriberClass();
            var publisher = new PublisherClass();

            publisher.DoWork();
            publisher.DoAnotherWork();

            Console.Read();
        }
    }
}