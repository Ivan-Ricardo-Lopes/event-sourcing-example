using IRL.EventSourcing.Infra.EntityFramework.DbContext;
using IRL.EventSourcing.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Infra.EntityFramework.Repositories
{
    public class FinanceAccountRepositoryEF : IFinanceAccountRepository
    {
        private readonly AppDbContext _db;

        public FinanceAccountRepositoryEF(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Exists(string customerCode)
        {
            return await _db.FinanceAccounts.AnyAsync(x => x.CustomerCode == customerCode);
        }
    }
}