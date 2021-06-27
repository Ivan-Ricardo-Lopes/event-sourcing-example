using Tactical.DDD;

namespace IRL.EventSourcing.Domain.FinanceAccounts.ValueObjects
{
    public class FinanceAccountId : EntityId
    {
        private int accountCode;

        public FinanceAccountId(string accountCode)
        {
            this.accountCode = int.Parse(accountCode);
        }

        public FinanceAccountId(int accountCode)
        {
            this.accountCode = accountCode;
        }

        public override string ToString() => accountCode.ToString();
    }
}