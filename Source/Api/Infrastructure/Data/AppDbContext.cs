using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Infrastructure.Data
{
    /// <summary>
    /// The class that defines the DbContext for the app
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Adds the table users to it of type <see cref="User"/>
        /// </summary>
        /// <value></value>
        public DbSet<User> Users { get; set; }
        
        /// <summary>
        /// The constructor for the AppDbContext
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}