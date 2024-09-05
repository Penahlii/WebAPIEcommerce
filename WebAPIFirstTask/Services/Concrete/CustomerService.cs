using System.Linq.Expressions;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Services.Concrete;

public class CustomerService : ICustomerService
{
    private readonly ICustomerDA _customerDA;

    public CustomerService(ICustomerDA customerDA)
    {
        _customerDA = customerDA;
    }

    public async Task AddAsync(Customer entity)
    {
        await _customerDA.Add(entity);
    }

    public async Task DeleteAsync(Customer entity)
    {
        await _customerDA.Delete(entity);
    }

    public async Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null)
    {
        return await _customerDA.GetList(filter);
    }

    public async Task<Customer> GetByIdAsync(int Id)
    {
        return await _customerDA.Get(c => c.Id == Id);
    }

    public async Task UpdateAsync(Customer entity)
    {
        await _customerDA.Update(entity);
    }
}
