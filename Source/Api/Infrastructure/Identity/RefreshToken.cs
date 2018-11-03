using System;
using Ardalis.GuardClauses;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    public class RefreshToken
    {
        public string Token { get; private set; }

        public DateTimeOffset Expires { get; private set; }

        public Guid UserId { get; private set; }

        public bool Active => DateTime.UtcNow <= Expires;

        public string IpAddress { get; private set; }

        public RefreshToken(string token, DateTimeOffset expires, Guid userId, string ipAddress)
        {
            Guard.Against.Null(token, nameof(token));
            Guard.Against.Null(ipAddress, nameof(ipAddress));

            Token = token;
            Expires = expires;
            UserId = userId;
            IpAddress = ipAddress;
        }

    }
}