using IRL.EventSourcing.Application.Common;
using MediatR;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit
{
    public class DepositCommand : IRequest<CommandResponse<DepositResponse>>
    {
        public int AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}