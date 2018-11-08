using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// A user of the application.
    /// </summary>
    public class AuthUser : IdentityUser
    {
        /// <summary>
        /// The Refresh Tokens of the user.
        /// </summary>
        /// <value></value>
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}