using System.Collections.Generic;
using SamMiller.Mumba.Api.Core.UseCases;

namespace SamMiller.Mumba.Api.Infrastructure.UseCases
{
    /// <summary>
    /// The implementation of the ICreateBoard interface
    /// </summary>
    public class CreateBoard : ICreateBoard
    {

        
        

        public System.Threading.Tasks.Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}