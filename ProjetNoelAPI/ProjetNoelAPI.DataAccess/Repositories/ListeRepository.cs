using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.DataAccess.Repositories
{
    public class ListeRepository : GenericRepository<Liste>, IListeRepository
    {
        public ListeRepository(NoelDbContext dbContext) : base(dbContext)
        {

        }
    }
}
