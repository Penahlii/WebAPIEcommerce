using WebAPIFirstTask.Repository.Abstraction;

namespace WebAPIFirstTask.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    // Foreign Keys

    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    // Navigation Properties

    public Customer Customer { get; set; }
    public Product Product { get; set; }
}
