using IRL.EventSourcing.Domain.Common.Events;

namespace IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents
{
    public class FinanceAccountCreated : DomainEvent
    {
        public FinanceAccountCreated(string id, int accountCode, string customerCode)
        {
            Id = id;
            AccountCode = accountCode;
            CustomerCode = customerCode;
        }

        public string Id { get; }
        public int AccountCode { get; }
        public string CustomerCode { get; }
    }
}