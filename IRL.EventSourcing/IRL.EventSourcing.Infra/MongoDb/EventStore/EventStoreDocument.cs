﻿using System;
using System.ComponentModel;

namespace IRL.EventSourcing.Infra.MongoDb.EventStore
{
    public class EventStoreDocument
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public int Version { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Description("ignore")]
        public int Sequence { get; set; }

        public string Name { get; set; }
        public string Aggregate { get; set; }
        public string AggregateId { get; set; }
    }
}