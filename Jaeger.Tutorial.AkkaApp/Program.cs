using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;

namespace Jaeger.Tutorial.AkkaApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Config configuration = ConfigurationFactory.ParseString(File.ReadAllText("akka.conf"));
            var system = ActorSystem.Create("Jaeger-Tutorial-AkkaApp", configuration);

            IActorRef pinger = system.ActorOf<PingActor>("pinger");
            IActorRef ponger = system.ActorOf<PongActor>("ponger");


            pinger.Tell(ponger);
            /*
            system
                .Scheduler
                .ScheduleTellOnce(TimeSpan.FromSeconds(0),
                //TimeSpan.FromSeconds(1),
                pinger, ponger, ActorRefs.NoSender);
            */

            Console.ReadLine();
        }
    }
}
