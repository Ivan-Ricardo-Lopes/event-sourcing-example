using System.Threading.Tasks;

namespace IRL.EventSourcing.Infra.Repositories
{
    public interface IFinanceAccountRepository
    {
        Task<bool> Exists(string customerCode);
    }
}