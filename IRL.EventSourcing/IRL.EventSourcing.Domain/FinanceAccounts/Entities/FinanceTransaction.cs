using IRL.EventSourcing.Domain.Common.Interfaces;
using IRL.EventSourcing.Domain.Common.ValueObjects;
using IRL.EventSourcing.Domain.FinanceAccounts.Enums;
using System;
using Tactical.DDD;

namespace IRL.EventSourcing.Domain.FinanceAccounts.Entities
{
    public class FinanceTransaction : Entity<GuidId>, IObjectWithState
    {
        public override GuidId Id { get; protected set; }
        public int AccountCode { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Description { get; set; }
        public State State { get; set; }

        public static class FinanceTransactionFactory
        {
            public static FinanceTransaction Create(string id, int accountCode, decimal amount, string description, TransactionType type, DateTime? CreatedDate = null, State? state = null)
            {
                return new FinanceTransaction()
                {
                    Id = new GuidId(id),
                    AccountCode = accountCode,
                    Amount = amount,
                    Description = description,
                    Type = type,
                    CreatedDate = CreatedDate ?? DateTime.UtcNow,
                    State = state ?? State.Added
                };
            }
        }
    }
}