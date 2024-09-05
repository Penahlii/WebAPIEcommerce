using System.Linq.Expressions;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Services.Concrete;

public class OrderService : IOrderService
{
    private readonly IOrderDA _orderDA;

    public OrderService(IOrderDA orderDA)
    {
        _orderDA = orderDA;
    }

    public async Task AddAsync(Order entity)
    {
        await _orderDA.Add(entity);
    }

    public async Task DeleteAsync(Order entity)
    {
        await _orderDA.Delete(entity);
    }

    public async Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
    {
        return await _orderDA.GetList(filter);
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orderDA.Get(o => o.Id == id);
    }

    public async Task UpdateAsync(Order entity)
    {
        await _orderDA.Update(entity);
    }
}
