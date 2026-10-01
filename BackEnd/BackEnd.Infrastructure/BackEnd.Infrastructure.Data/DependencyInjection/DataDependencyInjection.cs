using BackEnd.Infrastructure.Core.Database.Modules.Interfaces;
using BackEnd.Infrastructure.Data.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Data.DependencyInjection;

public static class DataDependencyInjection
{
    public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
    {
        services.AddSingleton<IInfrastructureModule, DataInfrastructureModule>();

        return services;
    }
}
