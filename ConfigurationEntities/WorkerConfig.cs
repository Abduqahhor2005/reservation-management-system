using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.ConfigurationEntities;

public class WorkerConfig : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasOne(w => w.Location)
            .WithOne(l => l.Worker)
            .HasForeignKey<Worker>(w => w.LocationId);

        builder.Property(x => x.Status).HasConversion<string>();
    }
}