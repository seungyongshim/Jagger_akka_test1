using System;
using System.Threading;
using Akka.Actor;
using Akka.Event;

namespace Jaeger.Tutorial.AkkaApp
{
    public class PingActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();

        public PingActor()
        {
            Receive<IActorRef>(actor =>
            {
                actor.Tell("Hello");
            });

            Receive<string>(str =>
            {
                Console.WriteLine($"{str} ");
                IActorRef sender = Sender;
                Thread.Sleep(10);
                Sender.Tell("Hello");
            });
        }
    }
}
