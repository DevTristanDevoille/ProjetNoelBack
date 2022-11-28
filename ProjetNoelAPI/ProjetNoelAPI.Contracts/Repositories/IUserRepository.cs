using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public List<User> GetUserInSquad(string code);
        public List<Liste> GetListesForUser(int id);
    }
}
