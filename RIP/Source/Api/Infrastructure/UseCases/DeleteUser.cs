using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Core.UseCases;

namespace SamMiller.Mumba.Api.Infrastructure.UseCases
{
    /// <summary>
    /// The implementation of the IDeleteUser interface
    /// </summary>
    public class DeleteUser : IDeleteUser
    {
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Constructor to create a usermanager for DeleteUser
        /// </summary>
        /// <param name="userManager"></param>
        public DeleteUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// The task of actually deleting a user
        /// </summary>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <returns>Success state</returns>
        public async Task HandleAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var user = await _userManager.FindByNameAsync(username);

            if( user !=null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }
}