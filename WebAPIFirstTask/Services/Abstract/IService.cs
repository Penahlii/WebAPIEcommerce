using WebAPIFirstTask.Repository.Abstraction;

namespace WebAPIFirstTask.Services.Abstract;

public interface IService<T> where T : IEntity
{
}
