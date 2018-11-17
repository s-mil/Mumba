using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamMiller.Mumba.Models
{
    /// <summary>
    /// A task for a board
    /// </summary>
    public class Task
    {
         /// <summary>
        /// The Id for this task
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// The Id for the board associated with this task
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
        /// The list position (1-3) of this task on the board
        /// </summary>
        public int ListNum { get; set; }  

        /// <summary>
        /// The title of this task
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description for this task
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// The due date for the task
        /// </summary>
        public DateTime DueDate { get; set; }
        
        /// <summary>
        /// True if the task is open
        /// </summary>
        public bool Open { get; set; }

    }
}