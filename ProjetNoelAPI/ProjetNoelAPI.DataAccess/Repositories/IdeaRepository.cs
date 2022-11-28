using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.DataAccess.Repositories
{
    public class IdeaRepository : GenericRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(NoelDbContext dbContext):base(dbContext)
        {

        }
    }
}
