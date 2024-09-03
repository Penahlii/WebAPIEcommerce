using Microsoft.EntityFrameworkCore;
using WebAPIFirstTask.Entities;

namespace WebAPIFirstTask.Data;

public class WebAPIECommerceDbContext : DbContext
{
    public WebAPIECommerceDbContext(DbContextOptions<WebAPIECommerceDbContext> options)
        : base(options) { }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Product> Products { get; set; }  
}
