using BP.Areas.mvcProject.Abstract;
using System.Collections.Generic;
using System.Data.Entity;

namespace BP.Areas.mvcProject.Repository
{
   public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public DbSet<T> Entity { get; set; }
      public  BaseRepository(DbContext Context)
        {
            this.Context = Context;
            Entity = Context.Set<T>();
        }
        public void add(T item)
        {
            Entity.Add(item);
        }

        public T get(int id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return Entity;
        }

        public void remove(int id)
        {
            Entity.Remove(Entity.Find(id));
        }
        public void savechange()
        {
            Context.SaveChanges();
        }
        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }
    }
}
