using System;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public class RefreshToken
    {
        public string Token { get; set; }

        public DateTimeOffset ExpirationTime { get; set; }

        public string IpAddress { get; set; }
    }
}