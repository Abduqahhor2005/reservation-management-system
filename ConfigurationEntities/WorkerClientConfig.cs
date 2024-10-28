using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.ConfigurationEntities;

public class WorkerClientConfig : IEntityTypeConfiguration<WorkerClient>
{
    public void Configure(EntityTypeBuilder<WorkerClient> builder)
    {
        builder
            .HasKey(wc => new { wc.WorkerId, wc.ClientId });

        builder
            .HasOne(wc => wc.Worker)
            .WithMany(w => w.WorkerClients)
            .HasForeignKey(wc => wc.WorkerId);

        builder
            .HasOne(wc => wc.Client)
            .WithMany(c => c.WorkerClients)
            .HasForeignKey(wc => wc.ClientId);
    }
}