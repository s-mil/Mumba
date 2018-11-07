using System;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The class that defines Tasks
    /// </summary>
    public class TaskItem : IEntity<Guid>
    {   
        /// <summary>
        /// The unique id of the task
        /// </summary>
        /// <value></value>
        public Guid Id { get; private set; }
        /// <summary>
        /// The title of the task
        /// </summary>
        /// <value></value>
        public string Title { get; private set; }

        /// <summary>
        /// The constructor for the task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public TaskItem(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

    }
}