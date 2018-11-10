using System;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for moving a task from one list to another list on the same board.
    /// </summary>
    public interface IMoveTask
    {
        /// <summary>
        /// The stub for moving a task from one list to another list on the same board.
        /// </summary>
        /// <param name="boardID">The unique id of the board</param>
        /// <param name="taskID">The unique id of the task</param>
        /// <param name="newList">The destination list [0:2]</param>
        Task HandleAsync(Guid boardID, Guid taskID, int newList);
        
    }
}