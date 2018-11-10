using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Core.UseCases;

namespace SamMiller.Mumba.Api.Infrastructure.UseCases
{
    /// <summary>
    /// The implementation of the ICreateUser interface
    /// </summary>
    public class CreateUser : ICreateUser
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// The constructor for a Usermanager
        /// </summary>
        /// <param name="userManager"></param>
        public CreateUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// The task of creating a user
        /// </summary>
        /// <param name="username">The username of the user to be created</param>
        /// <param name="password">The password of the user to be created</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var newUser = new User
            {
                UserName = username
            };

            var createUserResult = await _userManager.CreateAsync(newUser, password);

            if(!createUserResult.Succeeded)
            {
                return (false, createUserResult.Errors.Select(error => error.Description));
            }

            return (true, null);

        }
    }
}