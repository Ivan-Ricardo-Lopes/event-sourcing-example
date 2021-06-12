using System.Collections.Generic;
using Tactical.DDD;

namespace IRL.EventSourcing.Domain.FinanceAccounts.ValueObjects
{
    public class Balance : ValueObject
    {
        public Balance(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }

        public void Add(decimal amount)
        {
            this.Amount += amount;
        }

        public void Remove(decimal amount)
        {
            this.Amount -= amount;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
        }
    }
}