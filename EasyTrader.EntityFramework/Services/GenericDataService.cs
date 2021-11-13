using EasyTrader.Domain.Models;
using EasyTrader.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly EasyTraderDbContextFactory contextFactory;
        public GenericDataService(EasyTraderDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<T> Add(T entity)
        {
            using (EasyTraderDbContext context = this.contextFactory.CreateDbContext())
            {
                EntityEntry<T> entryResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entryResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (EasyTraderDbContext context = this.contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
                context.Set<T>().Remove(entity);
                bool isSaved = await context.SaveChangesAsync() > 0;
                return isSaved;
            }
        }

        public async Task<T> Get(int id)
        {
            using (EasyTraderDbContext context = this.contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (EasyTraderDbContext context = this.contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (EasyTraderDbContext context = this.contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
