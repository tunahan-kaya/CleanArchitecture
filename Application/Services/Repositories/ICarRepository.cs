using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, Guid> //,IRepository<Brand,Guid>   //:senkron repository
{

}
