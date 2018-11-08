using System;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// The class that defines an AccessToken
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The Token string
        /// </summary>
        /// <value></value>
        public string Token { get; set; }
        
        /// <summary>
        /// The expiration time for access tokens
        /// </summary>
        /// <value></value>
        public DateTimeOffset Expires { get; set; }
    }
}