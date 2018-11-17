
namespace SamMiller.Mumba.Models.TaskViewModels
{
    /// <summary>
    /// Models the detailed view of a task
    /// </summary>
    public class TaskDetails
    {
        /// <summary>
        /// The board the task belongs to
        /// </summary>
        /// <value>The board</value>
        public Board Board { get; set; }
        
        
        /// <summary>
        /// Gets the task
        /// </summary>
        /// <value>The task</value>
        public Task Task { get; set; }        
    }
}