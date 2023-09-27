
using dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration configuration;

    public DataContext(IConfiguration _configuration, DbContextOptions<DataContext> options) : base(options)
    {
        configuration = _configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseNpgsql(configuration.GetConnectionString("DATABASE_STRING"));
        base.OnConfiguring(optionsBuilder);

    }

    public DbSet<User> Users { get; set; }
}
