using System.Collections.Generic;
using SamMiller.Mumba.Models;

namespace SamMiller.Mumba.Models.BoardViewModels
{
    public class BoardsView
    {
        /// <summary>
        /// Gets User
        /// </summary>
        public AppUser user { get; set; }

        /// <summary>
        /// List of Boards associated with the user
        /// </summary>
        /// <returns>Users boards</returns>
        public IEnumerable<Board> Board { get; set; }
    }
}