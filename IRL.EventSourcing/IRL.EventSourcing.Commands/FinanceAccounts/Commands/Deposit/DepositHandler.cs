using IRL.EventSourcing.Application.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit
{
    public class DepositHandler : IRequestHandler<DepositCommand, CommandResponse<DepositResponse>>
    {
        private readonly DepositValidator _validator;

        public DepositHandler(DepositValidator validator)
        {
            this._validator = validator;
        }

        public async Task<CommandResponse<DepositResponse>> Handle(DepositCommand request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}