using IRL.EventSourcing.Domain.FinanceAccounts.Enums;
using System;

namespace IRL.EventSourcing.Business.FinanceAccounts.UseCases.AccountStatement
{
    public class AccountStatementResponse
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}