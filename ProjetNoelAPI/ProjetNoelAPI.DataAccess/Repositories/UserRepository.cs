﻿using ProjetNoelAPI.Contracts.Repositories;
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

        public List<Liste> GetListesForUser(int id)
        {
            return _dbContext.Users.Where(u => u.Id == id).SelectMany(u => u.Listes).ToList();
        }
    }
}
