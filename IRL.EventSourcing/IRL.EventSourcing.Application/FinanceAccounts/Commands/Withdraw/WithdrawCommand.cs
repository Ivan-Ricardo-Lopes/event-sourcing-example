using IRL.EventSourcing.Application.Common;
using MediatR;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Withdraw
{
    public class WithdrawCommand : IRequest<CommandResponse<WithdrawResponse>>
    {
        public int AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}