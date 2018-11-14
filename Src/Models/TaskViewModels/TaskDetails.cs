
namespace SamMiller.Mumba.Models.TaskViewModels
{
    /// <summary>
    /// Models the detailed view of a task
    /// </summary>
    public class TaskDetails
    {
        /// <summary>
        /// Gets the task
        /// </summary>
        /// <value>The task</value>
        public Task task { get; set; }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <value>The user</value>
        public AppUser user { get; set; }
        
    }
}