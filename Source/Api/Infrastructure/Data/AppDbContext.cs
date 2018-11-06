using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}