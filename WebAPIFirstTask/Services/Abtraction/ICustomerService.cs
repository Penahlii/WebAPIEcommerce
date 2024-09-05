using System.Linq.Expressions;
using WebAPIFirstTask.Entities;

namespace WebAPIFirstTask.Services.Abtraction;

public interface ICustomerService
{
    Task<Customer> GetByIdAsync(int id);
    Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> filter = null);
    Task AddAsync(Customer entity);
    Task DeleteAsync(Customer entity);
    Task UpdateAsync(Customer entity);
}
