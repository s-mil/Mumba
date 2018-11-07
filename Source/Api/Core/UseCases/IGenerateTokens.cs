
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public interface IGenerateTokens
    {
        Task<(AccessToken, RefreshToken)> HandleAsync(string username, string password, string ipAddress);
    }
}