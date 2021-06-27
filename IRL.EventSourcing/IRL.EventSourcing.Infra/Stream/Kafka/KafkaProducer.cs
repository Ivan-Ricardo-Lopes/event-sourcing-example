using System;
using System.Threading.Tasks;
using Tactical.DDD;

namespace IRL.EventSourcing.Infra.Stream.Kafka
{
    public class KafkaProducer : IEventStream
    {
        public Task Publish(string topic, IDomainEvent @event, string partitionKey = null)
        {
            throw new NotImplementedException();
        }
    }
}