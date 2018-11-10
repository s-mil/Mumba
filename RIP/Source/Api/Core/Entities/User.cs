using System;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The user as defined for the application
    /// </summary>
    public class User : IdentityUser<Guid>, IEntity<Guid>
    { }
}