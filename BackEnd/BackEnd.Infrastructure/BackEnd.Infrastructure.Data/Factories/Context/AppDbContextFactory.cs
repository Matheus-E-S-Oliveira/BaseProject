using BackEnd.Infrastructure.Core.Database;
using BackEnd.Infrastructure.Core.Database.Modules;
using BackEnd.Infrastructure.Core.Database.Modules.Interfaces;
using BackEnd.Infrastructure.Data.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Infrastructure.Data.Factories.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "BackEnd.WebApi");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddUserSecrets("8a81d023-3ce0-435b-a0ec-812acfb2bc3f")
            .Build();


        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("A connection string 'DefaultConnection' não foi encontrada.");
        
        var modules = new IInfrastructureModule[]
            {
                new DataInfrastructureModule()
            };

        var infrastructureBuilder = new InfrastructureModelBuilder(modules);

        var databaseOptions = infrastructureBuilder.ConfigureDatabase();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
        {
            if (!string.IsNullOrWhiteSpace(databaseOptions.MigrationsAssembly))
                sqlOptions.MigrationsAssembly(databaseOptions.MigrationsAssembly);
        });

        return new AppDbContext(optionsBuilder.Options, infrastructureBuilder);
    }
}
