using Microsoft.EntityFrameworkCore;
using WebAPIFirstTask.Data;
using WebAPIFirstTask.Repository.DataAccess.EntityFramework;
using WebAPIFirstTask.Repository.DataAccess;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.DataAccess.Concrete.EFEntityFramework;
using WebAPIFirstTask.Services.Abtraction;
using WebAPIFirstTask.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICustomerDA, EFCustomerDA>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductDA, EFProductDA>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDA, EFOrderDA>();
builder.Services.AddScoped<IOrderService, OrderService>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<WebAPIECommerceDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
