using System;
using System.Threading;
using FluentScheduler;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var registry = new Registry();
            registry.NonReentrantAsDefault();

            registry.Schedule(() =>
            {
                var now = DateTime.Now;
                Thread.Sleep(3000);
                Console.WriteLine($"{now} - Hello, world!");
            }).ToRunNow().AndEvery(1).Seconds();

            JobManager.Initialize(registry);

            while (Console.ReadLine() != "q")
            {

            }
        }
    }
}
