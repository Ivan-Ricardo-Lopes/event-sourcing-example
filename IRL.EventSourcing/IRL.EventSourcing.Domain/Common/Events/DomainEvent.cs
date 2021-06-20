using System;
using Tactical.DDD;

namespace IRL.EventSourcing.Domain.Common.Events
{
    public class DomainEvent : IDomainEvent
    {

        public DomainEvent()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime CreatedAt { get; set; }
    }
}
