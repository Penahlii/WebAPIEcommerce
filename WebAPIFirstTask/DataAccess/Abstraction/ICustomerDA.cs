﻿using WebAPIFirstTask.Entities;
using WebAPIFirstTask.Repository.DataAccess;

namespace WebAPIFirstTask.DataAccess.Abstraction;

public interface ICustomerDA : IEntityRepository<Customer>
{
}
