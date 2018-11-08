using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// The definition of a DB context for the Auth User
    /// </summary>
    /// <typeparam name="AuthUser"></typeparam>
    public class AuthDbContext : IdentityUserContext<AuthUser>
    {
        /// <summary>
        /// Creates a new db instance.
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