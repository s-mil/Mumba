using System.Threading.Tasks;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Infrastructure.Identity;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for refreshing tokens
    /// </summary>
    public interface IRefreshTokens
    {
        /// <summary>
        /// The stub for the task of refreshing tokens
        /// </summary>
        /// <param name="accessToken">The access token for the user</param>
        /// <param name="refreshToken">The refresh token fo the user</param>
        /// <param name="ipAddress">The Ip address of the current session</param>
        /// <returns></returns>
        Task<(AccessToken, RefreshToken)> HandleAsync(string accessToken, string refreshToken, string ipAddress);
    }
}
