using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIFirstTask.DTOs.OrderDTOs;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Services.Abtraction;

namespace WebAPIFirstTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllAsync();
        var orderDtos = orders.Select(o => new OrderDTO
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            ProductName = o.Product.Name,
            CustomerFullName = $"{o.Customer.Name} {o.Customer.Surname}"
        });

        return Ok(orderDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        var orderDto = new OrderDTO
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            ProductName = order.Product.Name,
            CustomerFullName = $"{order.Customer.Name} {order.Customer.Surname}"
        };

        return Ok(orderDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderDTO orderDto)
    {
        var order = new Order
        {
            OrderDate = orderDto.OrderDate,
            ProductId = orderDto.ProductId,
            CustomerId = orderDto.CustomerId
        };

        await _orderService.AddAsync(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO orderDto)
    {
        var existingOrder = await _orderService.GetByIdAsync(id);
        if (existingOrder == null)
            return NotFound();

        existingOrder.OrderDate = orderDto.OrderDate;
        existingOrder.ProductId = orderDto.ProductId;
        existingOrder.CustomerId = orderDto.CustomerId;
        await _orderService.UpdateAsync(existingOrder);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        await _orderService.DeleteAsync(order);
        return NoContent();
    }
}
