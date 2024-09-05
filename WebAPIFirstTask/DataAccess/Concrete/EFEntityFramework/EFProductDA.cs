using WebAPIFirstTask.Data;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Repository.DataAccess.EntityFramework;

namespace WebAPIFirstTask.DataAccess.Concrete.EFEntityFramework;

public class EFProductDA : EFEntityRepositoryBase<Product, WebAPIECommerceDbContext>, IProductDA
{
    public EFProductDA(WebAPIECommerceDbContext context) : base(context)
    {

    }
}
