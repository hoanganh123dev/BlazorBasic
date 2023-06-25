using BlazorAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorAPI.Data
{
    public class BlazorDbContext : IdentityDbContext<User, Role,Guid>
    {
        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) :base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
