using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamMiller.Mumba.Models
{
    /// <summary>
    /// A board
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The Id for this board
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the owner of the board
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The title for the board
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor for new boards
        /// </summary>
        /// <param name="uId">The user ID of the person requesting a new board</param>
        /// <param name="title">The title of the board</param>
        public Board(string uId, string title)
        {
            Id = new System.Guid();
            UserId = uId;
            Title = title;
        }
    }
}