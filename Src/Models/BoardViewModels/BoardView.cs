using System.Collections.Generic;
using SamMiller.Mumba.Models;

namespace SamMiller.Mumba.Models.BoardViewModels
{
    /// <summary>
    /// The model for the data required to view a board
    /// </summary>
    public class BoardView
    {

        /// <summary>
        /// Gets board
        /// </summary>
        public Board Board {get; set;}

        /// <summary>
        /// List of Tasks associated with the Board
        /// </summary>
        /// <returns>Boards Tasks</returns>
        public IEnumerable<Task> Tasks { get; set; }

        /// <summary>
        /// List of tasks associated with this boards list 1
        /// </summary>
        public IEnumerable<Task> TaskL1 {get; set;}

        /// <summary>
        /// List of tasks associated with this boards list 2
        /// </summary>
        public IEnumerable<Task> TaskL2 {get; set;}
        
        /// <summary>
        /// List of tasks associated with this boards list 3
        /// </summary>
        public IEnumerable<Task> TaskL3 {get; set;}
    }
}