using IRL.EventSourcing.Application.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Withdraw
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand, CommandResponse<WithdrawResponse>>
    {
        private readonly WithdrawValidator _validator;

        public WithdrawHandler(WithdrawValidator validator)
        {
            this._validator = validator;
        }

        public async Task<CommandResponse<WithdrawResponse>> Handle(WithdrawCommand request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}