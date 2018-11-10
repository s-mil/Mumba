using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for deleting users
    /// </summary>
    public interface IDeleteUser
    {
        /// <summary>
        /// The stub of the task for deleting users
        /// </summary>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <returns></returns>
        Task HandleAsync(string username, string password);
    }
}