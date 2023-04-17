using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config;

public class AddressConfiguration : BaseEntityConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.Property(x => x.StreetName)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.StreetNumber)
           .HasMaxLength(16)
           .IsRequired();

        builder.Property(x => x.City)
           .HasMaxLength(100)
           .IsRequired();

        builder.Property(x => x.PostalCode)
           .HasMaxLength(16)
           .IsRequired();

        builder.Property(x => x.Country)
           .HasMaxLength(2)
           .IsRequired();

        base.Configure(builder);
    }
}