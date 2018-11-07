using System;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTimeOffset ExpirationTime { get; set; }
    }
}