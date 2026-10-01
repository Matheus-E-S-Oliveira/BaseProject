using BackEnd.Infrastructure.Core.Database.Modules.Interfaces;
using BackEnd.Infrastructure.Core.Database.Options;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Data.Modules;

public sealed class DataInfrastructureModule : IInfrastructureModule
{
    public void ConfigureDatabase(InfrastructureDatabaseOptions options)
    {
        options.MigrationsAssembly = typeof(DataInfrastructureModule).Assembly.GetName().Name;
    }

    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataInfrastructureModule).Assembly);
    }
}
