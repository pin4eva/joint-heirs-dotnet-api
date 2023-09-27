
using dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration configuration;

    public DataContext(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DATABASE_STRING"));

    }

    public DbSet<User> Users { get; set; }
}
