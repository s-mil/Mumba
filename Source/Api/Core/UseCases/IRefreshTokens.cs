using System.Threading.Tasks;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    public interface IRefreshTokens
    {
        Task<(AccessToken, RefreshToken)> HandleAsync(string accessToken, string refreshToken, string ipAddress);
    }
}
