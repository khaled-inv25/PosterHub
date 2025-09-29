using System.Linq.Expressions;

namespace PosterHub.Domain.Shared
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? FindById(object id, bool trackChanges);
    }
}
