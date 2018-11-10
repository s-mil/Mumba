 using System.Collections.Generic;
 using System.Threading.Tasks;

 namespace SamMiller.Mumba.Api.Core.UseCases
 {
     /// <summary>
     /// The interface for creating boards
     /// </summary>
     public interface ICreateBoard
     {
         /// <summary>
         /// The stub of the task for creating boards
         /// </summary>
         /// <param name="username">The username of the user requesting the creation of a board</param>
         /// <returns></returns>
         Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(string username) ;
         
     }
 }