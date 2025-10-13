using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Shared;
using PosterHub.EntityFramework.AppDbContext;
using System.Linq.Expressions;

namespace PosterHub.EntityFramework
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PosterHubDbContext Context;

        protected RepositoryBase(PosterHubDbContext posterHubDbContext)
        {
            Context = posterHubDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? Context.Set<T>().AsNoTracking() : Context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? Context.Set<T>().Where(expression).AsNoTracking() : Context.Set<T>().Where(expression);
        }

        public T? FindById(object id, bool trackChanges)
        {
            return !trackChanges ? Context.Set<T>().AsNoTracking().FirstOrDefault(e => EF.Property<object>(e, "Id") == id) : Context.Set<T>().Find(id);
        }
    }
}
