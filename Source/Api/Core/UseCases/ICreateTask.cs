using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamMiller.Mumba.Api.Core.UseCases
{
    /// <summary>
    /// The interface for creating a Task/Card
    /// </summary>
    public interface ICreateTask
    {
        /// <summary>
        /// The stub for the task of creating a task/card
        /// </summary>
        /// <param name="boardID">The unique ID of a board</param>
        /// <param name="List">The list the task is to be in [0:2]</param>
        /// <param name="taskTitle">The title of the task/card</param>
        Task<(bool Succeeded, IEnumerable<string> Errors)> HandleAsync(Guid boardID, int List, string taskTitle);

    }
}