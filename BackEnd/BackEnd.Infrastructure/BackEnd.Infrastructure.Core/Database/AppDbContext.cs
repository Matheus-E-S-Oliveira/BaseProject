using BackEnd.Infrastructure.Core.Database.Modules;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Core.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options, InfrastructureModelBuilder infrastructureModelBuilder) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        infrastructureModelBuilder.Configure(modelBuilder);
    }
}
