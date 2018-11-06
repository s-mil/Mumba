using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Core.Data;
using SamMiller.Mumba.Api.Core.Entities;
using SamMiller.Mumba.Api.Infrastructure.Identity;

namespace SamMiller.Mumba.Api.Infrastructure.Services
{
    public class UserService
    {
        private readonly UserManager<Identity.IdentityUser> _userManager;

        private readonly IAsyncRepository<User, Guid> _userRepository;

        public UserService(UserManager<Identity.IdentityUser> userManager, IAsyncRepository<Identity.IdentityUser, Guid> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var newAppUser = new Identity.IdentityUser
            {
                UserName = username
            };

            var createUserResult = await _userManager.CreateAsync(newAppUser, password);

            if (!createUserResult.Succeeded)
            {
                throw new RegisterUserException(createUserResult);
            }

            var newPeer = new User(newAppUser.Id);

            try
            {
                await _userRepository.AddAsync(newUser);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                await _userManager.DeleteAsync(newAppUser);

                throw new RegisterUserException($"The username '{username}' is already in use.", exception);
            }

        }

    }
}