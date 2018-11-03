using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Infrastructure.Identity;
using SamMiller.Mumba.doApi.Core.Entities;

namespace SamMiller.Mumba.Api.Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;
        public UserRepository(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var NewAppUser = new AppUser
            {
                UserName = username
            };

            var createUserResult = await _userManager.CreateAsync(NewAppUser, password);

            if (!createUserResult.Succeeded)
            {
                throw new CreateUserException(createUserResult);
            }

            var NewUser = new User
            {
                username = username
            };

            _appDbContext.Users.Add(NewUser);

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var AppUser = await _userManager.FindByNameAsync(username);
                await _userManager.DeleteAsync(AppUser);

                throw new CreateUserException($"The username '{username}' is already in use.", exception);
            }

        }
    }

    [Serializable]
    internal class CreateUserException : Exception
    {
        public CreateUserException(IdentityResult createUserResult) : this(createUserResult.Errors.Select(error => $"Code: {error.Code}; Description: {error.Description}.").Aggregate((error1, error2) => error1 + "\n" + error2))
        { }

        public CreateUserException(string message) : base(message)
        { }

        public CreateUserException(string message, Exception innerException) : base(message, innerException)
        { }

        protected CreateUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}