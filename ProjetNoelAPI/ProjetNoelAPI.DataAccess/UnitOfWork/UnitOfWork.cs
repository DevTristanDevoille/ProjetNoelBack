using ProjetNoelAPI.Contracts.Repositories;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.DataAccess.Repositories;

namespace ProjetNoelAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NoelDbContext _context;
        private IListeRepository? _listeRepository;
        private ISquadRepository? _squadRepository;
        private IUserRepository? _userRepository;
        private IIdeaRepository? _ideaRepository;

        public UnitOfWork(NoelDbContext context)
        {
            _context = context;
        }

        public IListeRepository ListeRepository
        {
            get { return _listeRepository = _listeRepository ?? new ListeRepository(_context); }
        }

        public ISquadRepository SquadRepository
        {
            get { return _squadRepository = _squadRepository ?? new SquadRepository(_context); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_context); }
        }

        public IIdeaRepository IdeaRepository
        {
            get { return _ideaRepository = _ideaRepository ?? new IdeaRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
