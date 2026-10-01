using BackEnd.Infrastructure.Core.Database;
using BackEnd.Infrastructure.Core.Database.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Core.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A connection string 'DefaultConnection' não foi encontrada.");

            var infrastructureBuilder = serviceProvider.GetRequiredService<InfrastructureModelBuilder>();

            var databaseOptions = infrastructureBuilder.ConfigureDatabase();

            options.UseSqlServer(connectionString, sqlOptions =>
            {
                if (!string.IsNullOrWhiteSpace(databaseOptions.MigrationsAssembly))
                    sqlOptions.MigrationsAssembly(databaseOptions.MigrationsAssembly);
            });
        });

        services.AddScoped<InfrastructureModelBuilder>();

        return services;
    }
}
