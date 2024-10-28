using Microsoft.EntityFrameworkCore;
using ReservationManagementSystem.ConfigurationEntities;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<WorkerClient> WorkerClients { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(WorkerConfig).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ClientConfig).Assembly);
        base.OnModelCreating(builder);
    }
}