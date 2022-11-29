using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.Contracts.Repositories
{
    public interface ISquadRepository : IGenericRepository<Squad>
    {
        public List<Squad> GetAllSquadsWithUser(User user);
    }
}
