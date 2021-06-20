using IRL.EventSourcing.Domain.Common.Events;
using System;

namespace IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents
{
    public class MoneyDeposited : DomainEvent
    {
        public MoneyDeposited(string transactionId, int accountCode, decimal amount, DateTime createdDate, string description)
        {
            TransactionId = transactionId;
            AccountCode = accountCode;
            Amount = amount;
            CreatedDate = createdDate;
            Description = description;
        }

        public string TransactionId { get; }
        public int AccountCode { get; }
        public decimal Amount { get; }
        public DateTime CreatedDate { get; }
        public string Description { get; }
    }
}