namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit
{
    public class DepositResponse
    {
        public int AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal Balance { get; set; }
    }
}