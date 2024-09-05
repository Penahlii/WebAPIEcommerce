using WebAPIFirstTask.Data;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Repository.DataAccess.EntityFramework;

namespace WebAPIFirstTask.DataAccess.Concrete.EFEntityFramework;

public class EFOrderDA : EFEntityRepositoryBase<Order, WebAPIECommerceDbContext>, IOrderDA
{
    public EFOrderDA(WebAPIECommerceDbContext context) : base(context)
    {

    }
}
