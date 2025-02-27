
using System.Linq.Expressions;
using GenericRepository.Core.DataAccess.EntityFramework;
using GenericRepository.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Core.DataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<bool> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                if (entity != null)
                {
                    var addEntity = context.Entry(entity);
                    addEntity.State = EntityState.Added;
                    var result = await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                if (entity != null)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                  await context.Set<TEntity>().ToListAsync() :
                  await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            using (TContext context = new TContext())
            {
                var entities = context.Set<TEntity>().AsQueryable();
                foreach (var includedPropery in includedProperties)
                {
                    entities = entities.Include(includedPropery);
                }
                return entities;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllIncludingAsync(string includedProperties)
        {
            using (TContext context = new TContext())
            {
                var entities = context.Set<TEntity>().AsQueryable();
                var relations = includedProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    foreach (var property in relations)
                    {
                        entities = entities.Include(property);
                    }
                    if (entities != null)
                    {
                        return entities.ToList();
                    }
                    return new List<TEntity>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    return new List<TEntity>();
                }
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }

        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                if (entity != null)
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }
    }
}
