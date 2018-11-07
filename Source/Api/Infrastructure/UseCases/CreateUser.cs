using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Core.UseCases;

namespace SamMiller.Mumba.Api.Infrastructure.UseCases
{
    public class CreateUser : ICreateUser
    {
        private readonly UserManager<User> _userManager;

        public CreateUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

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