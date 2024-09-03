using System.Linq.Expressions;
using WebAPIFirstTask.Repository.Abstraction;

namespace WebAPIFirstTask.Repository.DataAccess;

public interface IEntityRepository<T> where T : class, IEntity,new()
{
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
    Task Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
}
