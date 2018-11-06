using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Api.Infrastructure.Identity;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _appDbContext;

        public UserRepository(UserManager<User> userManager, AppDbContext AppDbContext)
        {
            _userManager = userManager;
            _appDbContext = AppDbContext;
        }

        public async Task CreateAsync(string username, string password)
        {
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));

            var NewAppUser = new User
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
                var User = await _userManager.FindByNameAsync(username);
                await _userManager.DeleteAsync(User);

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