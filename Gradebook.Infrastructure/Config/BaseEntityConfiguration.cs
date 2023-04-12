using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config;

public abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : Entity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .HasColumnType("datetime2(0)")
            .IsRequired();

        builder.Property(x => x.ModifiedAt)
           .HasColumnType("datetime2(0)")
           .IsRequired();
    }
}
