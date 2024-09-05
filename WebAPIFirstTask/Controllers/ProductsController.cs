using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIFirstTask.DTOs.ProductDTOs;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();
        var productDtos = products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Discount = p.Discount
        });

        return Ok(productDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        var productDto = new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Discount = product.Discount
        };

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDTO productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Discount = productDto.Discount
        };

        await _productService.AddAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO productDto)
    {
        var existingProduct = await _productService.GetByIdAsync(id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = productDto.Name;
        existingProduct.Price = productDto.Price;
        existingProduct.Discount = productDto.Discount;
        await _productService.UpdateAsync(existingProduct);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        await _productService.DeleteAsync(product);
        return NoContent();
    }

    [HttpGet("GetHigher")]
    public async Task<IActionResult> GetHigher()
    {
        var product = await _productService.GetHigherAsync();
        if (product != null)
            return Ok(product);
        return NotFound();
    }

    [HttpGet("GetHigherDiscount")]
    public async Task<IActionResult> GetHigherDiscount()
    {
        var product = await _productService.GetHigherDiscountAsync();
        if (product != null)
            return Ok(product);
        return NotFound();
    }
}
