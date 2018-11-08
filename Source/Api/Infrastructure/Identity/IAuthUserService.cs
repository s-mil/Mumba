using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// A set of commands for creating and authorizing users.
    /// </summary>
    public interface IAuthUserService
    {
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A result of the operation.</returns>
        Task<AuthResult> CreateAsync(string username, string password);

        /// <summary>
        /// Generates access and refresh tokens for a user and stores the refresh token.
        /// </summary>
        /// <returns>The tokens.</returns>
        Task<AuthResult<(AccessToken, RefreshToken)>> GenerateTokensAsync(string username, string password, string ipAddress);

        /// <summary>
        /// Generates a new access and refresh token given an expired access token and a valid refresh token. Stores the new refresh token and deletes the old one.
        /// </summary>
        /// <returns>The new tokens.</returns>
        Task<AuthResult<(AccessToken, RefreshToken)>> RefreshTokensAsync(string accessToken, string refreshToken, string ipAddress);
    }
}