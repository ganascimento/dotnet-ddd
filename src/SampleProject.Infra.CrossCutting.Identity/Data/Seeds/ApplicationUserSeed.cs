using Microsoft.EntityFrameworkCore;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Seeds;

public static class ApplicationUserSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = 1,
                Name = "ROOT",
                UserName = "ROOT",
                NormalizedUserName = "ROOT",
                Email = "ROOT",
                NormalizedEmail = "ROOT",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAED5gxxST5QzCKpdPJbMChGSV82qNqpuaD3OO9zSjxIx1XvJ8bt94BaFMlTMBnI94CA==", //Teste@123
                CreateAt = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );
    }


}