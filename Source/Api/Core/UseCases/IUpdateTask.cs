using System;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for updating  a task 
    /// </summary>
    public interface IUpdateTask
    {
        /// <summary>
        /// The stub for moving a task from one list to another list on the same board.
        /// </summary>
        /// <param name="boardID">The unique id of the board</param>
        /// <param name="taskID">The unique id of the task</param>
        Task HandleAsync(Guid boardID, Guid taskID);
        
    }
}