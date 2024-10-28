using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.ConfigurationEntities;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasOne(c => c.Location)
            .WithOne(l => l.Client)
            .HasForeignKey<Client>(c => c.LocationId);
    }
}