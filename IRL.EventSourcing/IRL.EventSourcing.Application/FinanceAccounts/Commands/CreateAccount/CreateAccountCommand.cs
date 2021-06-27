using IRL.EventSourcing.Application.Common;
using MediatR;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<CommandResponse<CreateAccountResponse>>
    {
        public string CustomerCode { get; set; }
    }
}