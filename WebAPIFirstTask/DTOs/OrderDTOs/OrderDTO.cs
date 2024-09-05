namespace WebAPIFirstTask.DTOs.OrderDTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; }
    public string CustomerFullName { get; set; }
}
