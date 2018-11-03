using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    public class IdentityUser : IdentityUser<Guid>
    {
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

        // public bool HasValidRefreshToken(string refreshToken)
        // {
        //     return _refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        // }

        public void AddRefreshToken(string token, string ipAddress, double daysToExpire = 5)
        {
            Guard.Against.Null(token, nameof(token));
            Guard.Against.Null(ipAddress, nameof(ipAddress));

            _refreshTokens.Add(new RefreshToken(token, DateTimeOffset.Now.AddDays(daysToExpire), Id, ipAddress));
        }

        // public void RemoveRefreshToken(string refreshToken)
        // {
        //     _refreshTokens.Remove(_refreshTokens.First(t => t.Token == refreshToken));
        // }

    }
}