using IRL.EventSourcing.Commands.Common;
using MediatR;
using System.Collections.Generic;

namespace IRL.EventSourcing.Business.FinanceAccounts.UseCases.AccountStatement
{
    public class AccountStatementQuery : IRequest<QueryResponse<List<AccountStatementResponse>>>
    {
        public string AccountCode { get; set; }
    }
}