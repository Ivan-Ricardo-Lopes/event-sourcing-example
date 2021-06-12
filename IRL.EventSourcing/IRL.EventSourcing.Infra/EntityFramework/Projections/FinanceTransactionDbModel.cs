using IRL.EventSourcing.Domain.Common.Interfaces;
using IRL.EventSourcing.Domain.FinanceAccounts.Enums;
using System;

namespace IRL.EventSourcing.Infra.EntityFramework.Projections
{
    public class FinanceTransactionDbModel : IObjectWithState
    {
        public string Id { get; set; }
        public int AccountCode { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
    }
}