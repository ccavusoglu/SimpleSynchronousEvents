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
            EventManager.GetInstance();

                    new SubscriberClass(1);
//
//            Task.Factory.StartNew(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(5);
//                    new SubscriberClass(i);
//                }
//            });

            var publisherClass = new PublisherClass();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    publisherClass.DoAnotherWork(i);
                }
            });

            Console.Read();
        }
    }
}