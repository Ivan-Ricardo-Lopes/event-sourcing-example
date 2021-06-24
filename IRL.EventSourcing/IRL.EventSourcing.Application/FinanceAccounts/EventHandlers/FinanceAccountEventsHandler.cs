using IRL.EventSourcing.Domain.FinanceAccounts.Entities;
using IRL.EventSourcing.Infra.MongoDb.EventStore;
using System.Threading.Tasks;
using Tactical.DDD;

namespace IRL.EventSourcing.Application.FinanceAccounts.EventHandlers
{
    public class FinanceAccountEventsHandler
    {
        private readonly IEventStore _eventStore;

        public FinanceAccountEventsHandler(IEventStore eventStore)
        {
            this._eventStore = eventStore;
        }

        public async Task Handle(IDomainEvent @event)
        {
            var aggregate = (FinanceAccount)await _eventStore.LoadAsync(null);

            //apply event
            //save on eventstore.
        }
    }
}