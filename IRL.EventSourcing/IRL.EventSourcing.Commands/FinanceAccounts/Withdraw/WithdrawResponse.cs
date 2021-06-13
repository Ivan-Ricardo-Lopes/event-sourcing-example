namespace IRL.EventSourcing.Commands.FinanceAccounts.Withdraw
{
    public class WithdrawResponse
    {
        public int AccountCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal Balance { get; set; }
    }
}