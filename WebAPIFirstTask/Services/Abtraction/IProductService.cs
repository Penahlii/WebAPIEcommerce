using System.Linq.Expressions;
using WebAPIFirstTask.DTOs.ProductDTOs;
using WebAPIFirstTask.Entities;

namespace WebAPIFirstTask.Services.Abtraction;

public interface IProductService
{
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null);
    Task AddAsync(Product entity);
    Task DeleteAsync(Product entity);
    Task UpdateAsync(Product entity);
    Task<ProductDTO> GetHigherAsync();
    Task<ProductDTO> GetHigherDiscountAsync();
}
