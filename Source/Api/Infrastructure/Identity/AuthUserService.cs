using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace SamMiller.Mumba.Api.Infrastructure.Identity
{

/// <summary>
/// Commands for modifying Application Users.
/// </summary>
public class AuthUserService : IAuthUserService
    {
        private readonly UserManager<AuthUser> _userManager;

        private readonly AuthDbContext _authDbContext;

        private readonly SymmetricSecurityKey _signingKey;

        private readonly TimeSpan _accessTokenLifetime;

        private readonly TimeSpan _refreshTokenLifetime;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="userManager">The userManager.</param>
        /// <param name="authDbContext">The authDbContext.</param>
        /// <param name="authOptions">The authOptions.</param>
        public AuthUserService(UserManager<AuthUser> userManager, AuthDbContext authDbContext, IOptions<AuthOptions> authOptions)
        {
            _userManager = userManager;
            _authDbContext = authDbContext;

            var options = authOptions.Value;

            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.TokenSigningKey));
            _accessTokenLifetime = TimeSpan.FromHours(options.AccessTokenLifetimeHours);
            _refreshTokenLifetime = TimeSpan.FromDays(options.RefreshTokenLifetimeDays);
        }

        /// <summary>
        /// Generates access and refresh tokens for a user and stores the refresh token.
        /// </summary>
        /// <returns>The tokens.</returns>
        public async Task<AuthResult<(AccessToken, RefreshToken)>> GenerateTokensAsync(string username, string password, string ipAddress)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));
            Guard.Against.Null(ipAddress, nameof(ipAddress));

            var user = await _userManager.FindByNameAsync(username);

            var result = new AuthResult<(AccessToken AccessToken, RefreshToken RefreshToken)>();

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                result.Errors.Add("Invalid username or password.");
                return result;
            }

            var accessToken = GenerateAccessToken(username);

            var refreshToken = GenerateRefreshToken(username, ipAddress);

            user.RefreshTokens.Add(refreshToken);

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                result.Succeeded = false;
                result.Errors.Add("Refresh token conflict. Try again.");
            }
            else
            {
                result.Succeeded = true;
                result.Value = (accessToken, refreshToken);
            }

            return result;
        }

        /// <summary>
        /// Generates a new access and refresh token given an expired access token and a valid refresh token. Stores the new refresh token and deletes the old one.
        /// </summary>
        /// <returns>The new tokens.</returns>
        public async Task<AuthResult<(AccessToken, RefreshToken)>> RefreshTokensAsync(string accessToken, string refreshToken, string ipAddress)
        {
            var result = new AuthResult<(AccessToken, RefreshToken)>();

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                ValidateLifetime = false
            };
            string username = null;
            try
            {
                var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out _);
                username = principal.Identity.Name;
            }
            catch (SecurityTokenException)
            {
                result.Errors.Add("Invalid access token.");
                result.Succeeded = false;
                return result;
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                result.Errors.Add("Invalid access token.");
                result.Succeeded = false;
                return result;
            }

            var matchedRefreshToken = user.RefreshTokens.FirstOrDefault(token => token.Token == refreshToken);

            if (matchedRefreshToken == null)
            {
                result.Errors.Add("Invalid refresh token.");
                result.Succeeded = false;
                return result;
            }

            if (matchedRefreshToken.IpAddress != ipAddress)
            {
                result.Errors.Add("IP address has changed. Please login again.");
                result.Succeeded = false;
                return result;
            }

            if (matchedRefreshToken.Expires > DateTime.UtcNow)
            {
                result.Errors.Add("Refresh token is expired. Please login again.");
                result.Succeeded = false;
                return result;
            }

            user.RefreshTokens.Remove(matchedRefreshToken);

            var newAccessToken = GenerateAccessToken(username);
            var newRefreshToken = GenerateRefreshToken(username, ipAddress);

            user.RefreshTokens.Add(newRefreshToken);

            result.Value = (newAccessToken, newRefreshToken);
            result.Succeeded = true;

            return result;
        }

        private RefreshToken GenerateRefreshToken(string username, string ipAddress)
        {
            var randomNumber = new byte[32];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(randomNumber);
            }

            return new RefreshToken
            {
                Expires = DateTime.UtcNow.Add(_refreshTokenLifetime),
                IpAddress = ipAddress,
                Username = username,
                Token = Convert.ToBase64String(randomNumber)
            };
        }

        private AccessToken GenerateAccessToken(string username)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.Add(_accessTokenLifetime),
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return new AccessToken
            {
                Token = tokenHandler.CreateEncodedJwt(tokenDescriptor),
                Expires = tokenDescriptor.Expires.Value
            };
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A result of the operation.</returns>
        public async Task<AuthResult> CreateAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var appUser = new AuthUser { UserName = username };

            var identityResult = await _userManager.CreateAsync(appUser, password);

            var result = new AuthResult
            {
                Succeeded = identityResult.Succeeded
            };

            if (!identityResult.Succeeded)
            {
                result.Errors = identityResult.Errors.Select(error => error.Description).ToList();
            }

            return result;
        }
    }
}