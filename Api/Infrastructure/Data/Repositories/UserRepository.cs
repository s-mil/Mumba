using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SamMiller.Mumba.Api.Infrastructure.Identity;

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

        public async Task CreateAsync(string username, string password){
            Guard.Against.Null(username, nameof(username));
            Guard.Against.Null(password, nameof(password));



        }
    }
}