using IRL.EventSourcing.Domain.Common.Interfaces;
using IRL.EventSourcing.Domain.Common.ValueObjects;
using IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents;
using IRL.EventSourcing.Domain.FinanceAccounts.Enums;
using IRL.EventSourcing.Domain.FinanceAccounts.ValueObjects;
using System;
using System.Collections.Generic;
using Tactical.DDD;

namespace IRL.EventSourcing.Domain.FinanceAccounts.Entities
{
    public class FinanceAccount : Tactical.DDD.EventSourcing.AggregateRoot<FinanceAccountId>, IObjectWithState
    {
        public FinanceAccount(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private FinanceAccount()
        {
        }

        public override FinanceAccountId Id { get; protected set; }
        public int AccountCode { get; private set; }
        public string CustomerCode { get; private set; }
        public Balance Balance { get; private set; }
        public ICollection<FinanceTransaction> FinanceTransactions { get; private set; }
        public State State { get; set; }

        public static FinanceAccount Create(int accountCode, string CustomerCode, out FinanceAccountCreated @event)
        {
            var account = new FinanceAccount();
            @event = new FinanceAccountCreated(new GuidId().ToString(), accountCode, CustomerCode);
            account.Apply(@event);
            return account;
        }

        public void Deposit(decimal amount, string description, out MoneyDeposited @event)
        {
            @event = new MoneyDeposited(Guid.NewGuid().ToString(), AccountCode, amount, DateTime.UtcNow, description);
            Apply(@event);
        }

        public void Withdraw(decimal amount, string description, out MoneyWithdrawn @event)
        {
            @event = new MoneyWithdrawn(Guid.NewGuid().ToString(), AccountCode, amount, DateTime.UtcNow, description);
            Apply(@event);
        }

        public void On(FinanceAccountCreated @event)
        {
            Id = new FinanceAccountId(@event.Id);
            AccountCode = @event.AccountCode;
            CustomerCode = @event.CustomerCode;
            this.State = State.Added;
            FinanceTransactions = new List<FinanceTransaction>();
            Balance = new Balance(0);
        }

        public void On(MoneyDeposited @event)
        {
            var transaction = FinanceTransaction.Create(@event.TransactionId, AccountCode, @event.Amount, @event.Description, TransactionType.Inbound);
            FinanceTransactions.Add(transaction);
            Balance.Add(@event.Amount);
            this.State = State.Modified;
        }

        public void On(MoneyWithdrawn @event)
        {
            var transaction = FinanceTransaction.Create(@event.TransactionId, AccountCode, @event.Amount, @event.Description, TransactionType.Outbound);
            FinanceTransactions.Add(transaction);
            Balance.Remove(@event.Amount);
            this.State = State.Modified;
        }
    }
}