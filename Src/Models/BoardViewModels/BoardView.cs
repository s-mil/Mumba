using System.Collections.Generic;
using SamMiller.Mumba.Models;

namespace SamMiller.Mumba.Models.BoardViewModels
{
    public class BoardView
    {
        /// <summary>
        /// Gets User
        /// </summary>
        public AppUser user { get; set; }

        /// <summary>
        /// Gets board
        /// </summary>
        public Board board {get; set;}

        /// <summary>
        /// List of Tasks associated with the Board
        /// </summary>
        /// <returns>Boards Tasks</returns>
        public IEnumerable<Task> Tasks { get; set; }
    }
}