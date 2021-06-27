using IRL.EventSourcing.Infra.EntityFramework.DbContext;
using IRL.EventSourcing.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Infra.EntityFramework.Repositories
{
    public class FinanceAccountCodeRepositoryEF : IFinanceAccountCodeRepository
    {
        private readonly AppDbContext _db;

        public FinanceAccountCodeRepositoryEF(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int?> GetLastAccountCode()
        {
            return (await _db.FinanceAccountCodes.LastOrDefaultAsync())?.AccountCode;
        }
    }
}