using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for creating users
    /// </summary>
    public  interface ICreateUser
    {
        /// <summary>
        /// The stub for the task of creating users
        /// </summary>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <returns></returns>
        Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(string username, string password);
    }
}