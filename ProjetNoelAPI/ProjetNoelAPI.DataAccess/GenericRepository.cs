﻿using Microsoft.EntityFrameworkCore;
using ProjetNoelAPI.Contracts;
using ProjetNoelAPI.DataAccess.DbContextNoel;
using ProjetNoelAPI.Models.Base;
using System.Linq.Expressions;

namespace ProjetNoelAPI.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly NoelDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;


        public GenericRepository(NoelDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }


        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity);
        }


        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.AddRange(entities);
        }


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
        }



        public T Get(int id)
        {
            return _entitiySet.FirstOrDefault(e => e.Id == id);
        }

        public T Get(Expression<Func<T,bool>> expression)
        {
            return _entitiySet.FirstOrDefault(expression);
        }


        public IEnumerable<T> GetAll()
        {
            return _entitiySet.AsEnumerable();
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _entitiySet.Where(expression).AsEnumerable();
        }


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entitiySet.ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.Where(expression).ToListAsync(cancellationToken);
        }


        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.FirstOrDefaultAsync(expression);
        }


        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }


        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities);
        }
    }
}
