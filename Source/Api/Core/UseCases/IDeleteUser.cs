using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    public interface IDeleteUser
    {
        Task HandleAsync(string username, string password);
    }
}