﻿namespace WebAPIFirstTask.DTOs.OrderDTOs;

public class CreateOrderDTO
{
    public DateTime OrderDate { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
}
