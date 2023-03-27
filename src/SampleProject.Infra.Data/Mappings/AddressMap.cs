using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Models;

namespace SampleProject.Infra.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .ToTable("TB_ADDRESS");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Street)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(p => p.City)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(p => p.State)
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(p => p.Country)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(p => p.ZipCode)
            .HasMaxLength(8)
            .IsRequired();

        builder
            .Property(p => p.BuildingNumber)
            .HasMaxLength(12)
            .IsRequired(false);

        builder
            .Property(p => p.Complement)
            .HasMaxLength(40)
            .IsRequired(false);
    }
}