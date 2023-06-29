using BlazorAPI.Entities;
using BlazorModel.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace BlazorAPI.Data
{
    public class BlazorDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(BlazorDbContext context, ILogger<BlazorDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
