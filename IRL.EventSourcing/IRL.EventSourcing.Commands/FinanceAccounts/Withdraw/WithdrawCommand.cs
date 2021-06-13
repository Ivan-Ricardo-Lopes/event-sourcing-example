using IRL.EventSourcing.Commands.Common;
using MediatR;

namespace IRL.EventSourcing.Commands.FinanceAccounts.Withdraw
{
    public class WithdrawCommand : IRequest<CommandResponse<WithdrawResponse>>
    {
        public int AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}