using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules)); //BaseBusinessRules türündeki assembly'i IoC'ye ekle.

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;

        /*
            Bütün assembly'i tara, orada command'leri ve query'leri bul.
            onları birbiriyle eşleştirip listene koy.
        */
    }

    //uygalama çalışmaya başladığında git assembly içerisinde BaseRules'ları bul, onları IoC'ye ekle.
    public static IServiceCollection AddSubClassesOfType(
       this IServiceCollection services,
       Assembly assembly,
       Type type,
       Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
   )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}