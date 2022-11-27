using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.DataAccess.Repositories
{
    public class SquadRepository : GenericRepository<Squad>, ISquadRepository
    {
        public SquadRepository(NoelDbContext dbContext) : base(dbContext)
        {

        }
    }

}
