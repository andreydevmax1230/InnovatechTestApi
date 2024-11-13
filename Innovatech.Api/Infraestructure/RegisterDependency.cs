using Innovatech.Domain.Repositories;
using Innovatech.Domain.UnitOfWork;
using Innovatech.Infraestructure;

namespace Innovatech.Api.Infraestructure;

public static class RegisterDependency
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}