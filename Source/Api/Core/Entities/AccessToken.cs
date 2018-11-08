using System;

namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The class that defines an AccessToken entity
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The Token 
        /// </summary>
        /// <value></value>
        public string Token { get; set; }
        
        /// <summary>
        /// The expiration time for access tokens
        /// </summary>
        /// <value></value>
        public DateTimeOffset ExpirationTime { get; set; }
    }
}