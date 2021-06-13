using IRL.EventSourcing.Infra.MongoDb.Connection;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tactical.DDD;

namespace IRL.EventSourcing.Infra.MongoDb.EventStore
{
    public class MongoEventStoreRepository : IEventStore
    {
        private readonly IMongoConnectionFactory connectionFactory;

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };

        public MongoEventStoreRepository(IMongoConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(IEntityId aggregateRootId)
        {
            if (aggregateRootId == null) throw new ArgumentException("AggregateRootId cannot be null");

            var database = connectionFactory.MongoDatabase();
            var collection = database.GetCollection<EventStoreDocument>("events");
            var filter = Builders<EventStoreDocument>.Filter.Where(x => x.AggregateId == aggregateRootId.ToString());
            var result = await collection.FindAsync(filter);
            var events = await result.ToListAsync();

            var domainEvents = events.Select(TransformEvent).Where(x => x != null).ToList().AsReadOnly();

            return domainEvents;
        }

        private IDomainEvent TransformEvent(EventStoreDocument eventSelected)
        {
            var o = JsonConvert.DeserializeObject(eventSelected.Data, _jsonSerializerSettings);
            var evt = o as IDomainEvent;

            return evt;
        }

        public async Task SaveAsync(IEntityId aggregateId, int originatingVersion, IReadOnlyCollection<IDomainEvent> events, string aggregateName = "Aggregate Name")
        {
            if (events.Count == 0) return;

            var database = connectionFactory.MongoDatabase();
            var collection = database.GetCollection<EventStoreDocument>("events");

            var listOfEvents = events.Select(ev => new EventStoreDocument
            {
                Aggregate = aggregateName,
                CreatedAt = ev.CreatedAt,
                Data = JsonConvert.SerializeObject(ev, Formatting.Indented, _jsonSerializerSettings),
                Id = Guid.NewGuid(),
                Name = ev.GetType().Name,
                AggregateId = aggregateId.ToString(),
                Version = ++originatingVersion
            });

            await collection.InsertManyAsync(listOfEvents);
        }
    }
}