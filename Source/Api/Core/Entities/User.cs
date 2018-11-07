using System;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    { }
}