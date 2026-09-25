using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Core.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

}
