using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) :base(options)
        { }
    }
}