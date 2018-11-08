
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    public class AuthDbContext : IdentityUserContext<User>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="options">The db context options.</param>
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        { }

        /// <summary>
        /// Configures entities.
        /// </summary>
        /// <param name="model">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<AuthUser>().HasMany<RefreshToken>().WithOne();

            model.Entity<RefreshToken>().HasKey(r => new { r.Token, r.Username });
        }

    }
}