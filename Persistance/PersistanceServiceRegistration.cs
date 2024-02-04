using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //InMemory
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));

        // "RentACar" isimli connectionstring'i kullan
            // (ConnectionString'i WebApi'de appsettings.json dosyasında belirledik)
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("RentACar")));


        services.AddScoped<IBrandRepository, BrandRepository>();
        return services;
    }
}
