using System.Linq.Expressions;
using WebAPIFirstTask.Entities;

namespace WebAPIFirstTask.Services.Abtraction;

public interface IOrderService
{
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null);
    Task AddAsync(Order entity);
    Task DeleteAsync(Order entity);
    Task UpdateAsync(Order entity);
}
