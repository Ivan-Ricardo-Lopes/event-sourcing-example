using System.Threading.Tasks;
using Tactical.DDD;

namespace IRL.EventSourcing.Infra.Stream
{
    public interface IEventStream
    {
        Task Publish(string topic, IDomainEvent @event, string partitionKey = null);
    }
}