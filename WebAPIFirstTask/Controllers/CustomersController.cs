using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIFirstTask.DTOs.CustomerDTOs;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerService.GetAllAsync();
        var customerDtos = customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            FullName = $"{c.Name} {c.Surname}"
        });

        return Ok(customerDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
            return NotFound();

        var customerDto = new CustomerDTO
        {
            Id = customer.Id,
            FullName = $"{customer.Name} {customer.Surname}"
        };

        return Ok(customerDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerDTO customerDto)
    {
        var customer = new Customer
        {
            Name = customerDto.Name,
            Surname = customerDto.Surname
        };

        await _customerService.AddAsync(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO customerDto)
    {
        var existingCustomer = await _customerService.GetByIdAsync(id);
        if (existingCustomer == null)
            return NotFound();

        existingCustomer.Name = customerDto.Name;
        existingCustomer.Surname = customerDto.Surname;
        await _customerService.UpdateAsync(existingCustomer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
            return NotFound();

        await _customerService.DeleteAsync(customer);
        return NoContent();
    }
}
