using BackEnd.Infrastructure.Core.Database.Modules.Interfaces;
using BackEnd.Infrastructure.Core.Database.Options;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Core.Database.Modules;

public sealed class InfrastructureModelBuilder(IEnumerable<IInfrastructureModule> modules)
{
    public void Configure(ModelBuilder modelBuilder)
    {
        foreach (var module in modules)
        {
            module.ConfigureModel(modelBuilder);
        }
    }

    public InfrastructureDatabaseOptions ConfigureDatabase()
    {
        var options = new InfrastructureDatabaseOptions();

        foreach (var module in modules)
        {
            module.ConfigureDatabase(options);
        }

        return options;
    }
}
