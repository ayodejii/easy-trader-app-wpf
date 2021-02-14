using EasyTrader.Domain.Models;
using EasyTrader.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly EasyTraderDbContextFactory _contextFactory;
        public GenericDataService(EasyTraderDbContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<T> Add(T entity)
        {
            using (EasyTraderDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> entryResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entryResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (EasyTraderDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
                context.Set<T>().Remove(entity);
                bool isSaved = await context.SaveChangesAsync() > 0;
                return isSaved;
            }
        }

        public async Task<T> Get(int id)
        {
            using (EasyTraderDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (EasyTraderDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (EasyTraderDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
