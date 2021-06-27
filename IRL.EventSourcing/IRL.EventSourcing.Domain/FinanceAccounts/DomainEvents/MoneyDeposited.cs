using IRL.EventSourcing.Domain.Common.Events;
using System;

namespace IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents
{
    public class MoneyDeposited : DomainEvent
    {
        public MoneyDeposited(string transactionId, int accountCode, decimal amount, DateTime createdAt, string description)
        {
            TransactionId = transactionId;
            AccountCode = accountCode;
            Amount = amount;
            CreatedAt = createdAt;
            Description = description;
        }

        public string TransactionId { get; }
        public int AccountCode { get; }
        public decimal Amount { get; }
        public string Description { get; }
    }
}