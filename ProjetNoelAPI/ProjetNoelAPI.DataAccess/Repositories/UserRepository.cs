using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NoelDbContext dbContext) : base(dbContext)
        {
            
        }

        public List<User> GetUserInSquad(string code)
        {
            return _dbContext?.Squades?.Where(s => s.Code == code).SelectMany(s => s.Users).ToList();
        }
    }
}
