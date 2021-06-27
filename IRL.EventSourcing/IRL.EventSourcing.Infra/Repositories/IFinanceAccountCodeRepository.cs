using System.Threading.Tasks;

namespace IRL.EventSourcing.Infra.Repositories
{
    public interface IFinanceAccountCodeRepository
    {
        Task<int?> GetLastAccountCode();
    }
}