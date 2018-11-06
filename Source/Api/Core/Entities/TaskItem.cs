using System;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public class TaskItem : IEntity<Guid>
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public TaskItem(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

    }
}