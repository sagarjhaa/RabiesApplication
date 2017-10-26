using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Web;


namespace RabiesApplication.Web.Repositories
{
    public abstract class BaseRepository<TEntity> : IDisposable where TEntity : class
    {
        public DataContext Context { get; set; }

        public BaseRepository()
        {
            Context = DataContext.Create();
        }

        public virtual IQueryable<TEntity> All() => Context.Set<TEntity>().AsQueryable();

        public abstract Task<TEntity> GetById(string id);

        public abstract Task Insert(TEntity model);
        public abstract Task Update(TEntity model);

        public virtual async Task DeleteAsync(string id)
        {
            var model = await GetById(id);
            if (model != null)
                Context.Set<TEntity>().Remove(model);
        }

        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
