using WebAPIFirstTask.Repository.Abstraction;

namespace WebAPIFirstTask.Entities;

public class Customer : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public ICollection<Order> Orders { get; set; } // Navigation Property
}
