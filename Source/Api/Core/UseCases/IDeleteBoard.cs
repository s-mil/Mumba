using System;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for deleting boards
    /// </summary>
    public interface IDeleteBoard
    {
        /// <summary>
        /// The task stub for deleting boards
        /// </summary>
        /// <param name="boardID">The unique ID of a board</param>
        Task HandleAsync(Guid boardID);
    }
}