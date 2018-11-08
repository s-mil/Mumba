
using System.Threading.Tasks;
using SamMiller.Mumba.Api.Infrastructure.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The interface for creating tokens
    /// </summary>
    public interface IGenerateTokens
    {
        /// <summary>
        /// The stub for the task of creating tokens
        /// </summary>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <param name="ipAddress">The Ip address of the current session</param>
        /// <returns></returns>
        Task<(AccessToken, RefreshToken)> HandleAsync(string username, string password, string ipAddress);
    }
}