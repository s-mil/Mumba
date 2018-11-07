using System;

namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The Class that defines refresh tokens
    /// </summary>
    public class RefreshToken
    {   
        /// <summary>
        /// The token part of the refresh token
        /// </summary>
        /// <value></value>
        public string Token { get; set; }
        
        /// <summary>
        /// The time the refresh token expires 
        /// </summary>
        /// <value></value>
        public DateTimeOffset ExpirationTime { get; set; }
        /// <summary>
        /// The IP address that received the token
        /// </summary>
        /// <value></value>
        public string IpAddress { get; set; }
    }
}