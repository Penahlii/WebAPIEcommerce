using WebAPIFirstTask.Data;
using WebAPIFirstTask.DataAccess.Abstraction;
using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Repository.DataAccess.EntityFramework;

namespace WebAPIFirstTask.DataAccess.Concrete.EFEntityFramework;

public class EFCustomerDA : EFEntityRepositoryBase<Customer, WebAPIECommerceDbContext>, ICustomerDA
{
    public EFCustomerDA(WebAPIECommerceDbContext context) : base(context)
    {

    }
}
