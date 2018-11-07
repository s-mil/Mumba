using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    public  interface ICreateUser
    {
        Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(string username, string password);
    }
}