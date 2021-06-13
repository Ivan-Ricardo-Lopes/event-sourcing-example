using IRL.EventSourcing.Commands.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Commands.FinanceAccounts.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CommandResponse<CreateAccountResponse>>
    {
        private readonly CreateAccountValidator _validator;

        public CreateAccountHandler(CreateAccountValidator validator)
        {
            this._validator = validator;
        }

        public async Task<CommandResponse<CreateAccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}