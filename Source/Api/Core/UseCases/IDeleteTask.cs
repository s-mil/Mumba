using System;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for deleting tasks
    /// </summary>
    public interface IDeleteTask
    {
        /// <summary>
        /// The task stub for deleting tasks
        /// </summary>
        /// <param name="taskID">The unique ID of a board</param>
        Task HandleAsync(Guid taskID);
    }
}