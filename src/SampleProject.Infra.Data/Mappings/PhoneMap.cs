using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Models;

namespace SampleProject.Infra.Data.Mappings;

public class PhoneMap : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder
            .ToTable("TB_PHONE");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.AreaCode)
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(9)
            .IsRequired();
    }
}