using IRL.EventSourcing.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace IRL.EventSourcing.Application.FinanceAccounts.Queries.AccountStatement
{
    public class AccountStatementQuery : IRequest<QueryResponse<List<AccountStatementResponse>>>
    {
        public string AccountCode { get; set; }
    }
}