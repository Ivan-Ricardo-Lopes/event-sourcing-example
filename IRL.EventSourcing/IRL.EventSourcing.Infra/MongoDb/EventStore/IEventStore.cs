using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactical.DDD;

namespace IRL.EventSourcing.Infra.MongoDb.EventStore
{
    public interface IEventStore
    {
        Task SaveAsync(IEntityId aggregateId,
            int originatingVersion,
            IReadOnlyCollection<IDomainEvent> events,
            string aggregateName);

        Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(IEntityId aggregateRootId);
    }
}