using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Models;

namespace SampleProject.Infra.Data.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("TB_EMPLOYEE");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.Document)
            .HasMaxLength(11)
            .IsRequired();

        builder
            .Property(p => p.MotherName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.FatherName)
            .HasMaxLength(100)
            .IsRequired(false);

        builder
            .Property(p => p.Sex)
            .IsRequired();

        builder
            .Property(p => p.BirthDate)
            .IsRequired();

        builder.HasOne(p => p.Address);

        builder.HasOne(p => p.Telephone);

        builder.HasOne(p => p.Cellphone);

        builder
            .HasOne(p => p.Company)
            .WithMany(p => p.Employees)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(n => n.Address).AutoInclude();

        builder.Navigation(n => n.Cellphone).AutoInclude();

        builder.Navigation(n => n.Telephone).AutoInclude();
    }
}