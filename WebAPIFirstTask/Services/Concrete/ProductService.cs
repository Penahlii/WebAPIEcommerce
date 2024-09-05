using System.Linq.Expressions;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.DTOs.ProductDTOs;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Services.Concrete;

public class ProductService : IProductService
{
    private readonly IProductDA _productDA;

    public ProductService(IProductDA productDA)
    {
        _productDA = productDA;
    }

    public async Task AddAsync(Product entity)
    {
        await _productDA.Add(entity);
    }

    public async Task DeleteAsync(Product entity)
    {
        await _productDA.Delete(entity);
    }

    public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
    {
        return await _productDA.GetList(filter);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productDA.Get(p => p.Id == id);
    }

    public async Task<ProductDTO> GetHigherAsync()
    {
        var products = await _productDA.GetList();

        var mostExpensiveProduct = products
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();

        if (mostExpensiveProduct == null)
            return null;

        return new ProductDTO
        {
            Id = mostExpensiveProduct.Id,
            Name = mostExpensiveProduct.Name,
            Price = mostExpensiveProduct.Price,
            Discount = mostExpensiveProduct.Discount
        };
    }

    public async Task<ProductDTO> GetHigherDiscountAsync()
    {
        var products = await _productDA.GetList();

        var mostDiscountedProduct = products
            .OrderByDescending(p => p.Discount)
            .FirstOrDefault();

        if (mostDiscountedProduct == null)
            return null;

        return new ProductDTO
        {
            Id = mostDiscountedProduct.Id,
            Name = mostDiscountedProduct.Name,
            Price = mostDiscountedProduct.Price,
            Discount = mostDiscountedProduct.Discount
        };
    }

    public async Task UpdateAsync(Product entity)
    {
        await _productDA.Update(entity);
    }
}
