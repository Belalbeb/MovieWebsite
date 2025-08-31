
using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce_App.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
      protected readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public void Add(T entity)
        {

            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Set<T>().FirstOrDefault(s => s.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll() => context.Set<T>().ToList();







        public virtual T GetById(int id) => context.Set<T>().FirstOrDefault(s => s.Id == id);






        public async Task Update(int id, T entity)
        {
            var existing = await context.Set<T>().FindAsync(id);
            if (existing == null)
                throw new Exception($"{typeof(T).Name} with id {id} not found");

            // رجّع الـ Id عشان ما يبقاش 0
            context.Entry(entity).Property("Id").CurrentValue = id;

            context.Entry(existing).CurrentValues.SetValues(entity);
            context.Entry(existing).Property("Id").IsModified = false;

            await context.SaveChangesAsync();
        }

    }
} 