using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Models;

namespace SamMiller.Mumba.Data
{
    /// <summary>
    /// The context for the GoldenTicket Api
    /// </summary>
    public class MumbaContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// The collection of Users
        /// </summary>
        public DbSet<AppUser> Users { get; set; }

        /// <summary>
        /// The collection of boards
        /// </summary>
        public DbSet<Board> Boards { get; set; }

        /// <summary>
        /// The collection of tasks
        /// </summary>
        public DbSet<Task> Tasks { get; set; }


        /// <summary>
        /// The constructor for this context
        /// </summary>
        /// <param name="options">The options to create the context around</param>
        /// <returns>A new instance of this context</returns>
        public MumbaContext(DbContextOptions<MumbaContext> options) : base(options)
        { }
    }
}