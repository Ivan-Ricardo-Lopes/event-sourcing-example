using IRL.EventSourcing.Commands.Common;
using MediatR;

namespace IRL.EventSourcing.Commands.FinanceAccounts.CreateAccount
{
    public class CreateAccountCommand : IRequest<CommandResponse<CreateAccountResponse>>
    {
        public string CustomerCode { get; set; }
        public int AccountCode { get; set; }
    }
}