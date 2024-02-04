using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITransmissionRepository : IAsyncRepository<Transmission, Guid> //,IRepository<Brand,Guid>   //:senkron repository
{

}