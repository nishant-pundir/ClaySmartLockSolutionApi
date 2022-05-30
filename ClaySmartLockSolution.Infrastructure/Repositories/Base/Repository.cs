﻿using ClaySmartLockSolution.Core.Repositories.Base;
using ClaySmartLockSolution.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ClaySmartLockSolution.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UserContext _userContext;
        public Repository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _userContext.Set<T>().AddAsync(entity);
            await _userContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _userContext.Set<T>().Remove(entity);
            await _userContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _userContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await _userContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
