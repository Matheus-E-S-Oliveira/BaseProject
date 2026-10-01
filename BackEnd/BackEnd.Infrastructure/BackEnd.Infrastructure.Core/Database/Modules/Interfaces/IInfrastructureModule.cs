using BackEnd.Infrastructure.Core.Database.Options;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Core.Database.Modules.Interfaces;

public interface IInfrastructureModule
{
    void ConfigureModel(ModelBuilder modelBuilder);

    void ConfigureDatabase(InfrastructureDatabaseOptions options);
}
