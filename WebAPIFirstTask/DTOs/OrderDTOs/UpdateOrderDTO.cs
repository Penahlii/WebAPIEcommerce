namespace WebAPIFirstTask.DTOs.OrderDTOs;

public class UpdateOrderDTO // This is same with Creation DTO but it should be written for further changes that will take place.
{
    public DateTime OrderDate { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
}
