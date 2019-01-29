using System;
using Akka.Actor;
using Akka.Event;

namespace Jaeger.Tutorial.AkkaApp
{
    public class PongActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private long _count;

        public PongActor()
        {
            Receive<string>(str =>
            {
                _count++;
                Console.Write($"{str} ");
                Sender.Tell($"world {_count}");
            });
        }
    }
}
