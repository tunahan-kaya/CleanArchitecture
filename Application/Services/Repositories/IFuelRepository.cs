using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IFuelRepository : IAsyncRepository<Fuel, Guid> //,IRepository<Brand,Guid>   //:senkron repository
{

}
