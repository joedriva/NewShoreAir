﻿using System.Collections;
using NewShoreAir.Application.Contracts.Persistence;
using NewShoreAir.Domain.Common;
using NewShoreAir.Infrastructure.Persistence;

namespace NewShoreAir.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly NewShoreAirDbContext _context;
        
        public UnitOfWork(NewShoreAirDbContext context)
        {
            _context = context;
        }

        public NewShoreAirDbContext NewShoreAirDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(AsyncRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
