using WebAPIFirstTask.Repository.Abstraction;

namespace WebAPIFirstTask.Entities;

public class Product : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public ICollection<Order> Orders { get; set; } // Navigation Property (this can be optional)
}
