using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Models;
using SampleProject.Infra.Data.Mappings;

namespace SampleProject.Infra.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new CompanyMap());
        modelBuilder.ApplyConfiguration(new EmployeeMap());
        modelBuilder.ApplyConfiguration(new PhoneMap());
    }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Phone> Phone { get; set; }
    public DbSet<Address> Address { get; set; }
}