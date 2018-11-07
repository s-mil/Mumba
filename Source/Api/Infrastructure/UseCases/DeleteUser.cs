using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Core.UseCases;

namespace SamMiller.Mumba.Api.Infrastructure.UseCases
{
    public class DeleteUser : IDeleteUser
    {
        private readonly UserManager<User> _userManager;

        public DeleteUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


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