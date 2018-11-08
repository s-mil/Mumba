using System;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// The Class that defines refresh tokens
    /// </summary>
    public class RefreshToken
    {   
         /// <summary>
        /// The token string.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The expiration time.
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// The username for the user of the token.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The IP Address that was used to generate the token.
        /// </summary>
        public string IpAddress { get; set; }
    }
}