using IRL.EventSourcing.Commands.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Commands.FinanceAccounts.Deposit
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