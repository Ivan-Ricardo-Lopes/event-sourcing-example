using IRL.EventSourcing.Commands.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Business.FinanceAccounts.UseCases.AccountStatement
{
    public class AccountStatementHandler : IRequestHandler<AccountStatementQuery, QueryResponse<List<AccountStatementResponse>>>
    {
        public AccountStatementHandler()
        {
        }

        public async Task<QueryResponse<List<AccountStatementResponse>>> Handle(AccountStatementQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}