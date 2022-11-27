using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.Contracts.Services;

namespace ProjetNoelAPI.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IListeRepository ListeRepository { get; }
        ISquadRepository SquadRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
