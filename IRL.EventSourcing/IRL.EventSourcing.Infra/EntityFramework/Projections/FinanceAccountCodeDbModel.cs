using System.ComponentModel.DataAnnotations;

namespace IRL.EventSourcing.Infra.EntityFramework.Projections
{
    public class FinanceAccountCodeDbModel
    {
        [Key]
        public string FinanceAccountId { get; set; }

        public int AccountCode { get; set; }
    }
}