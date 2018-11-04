using System;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Core.Entities
{
    public class Task : IEntity<Guid>
    {
        public Guid ID { get; private set; }
        public string Title { get; private set; }

        public Task(Guid id, string title)
        {
            ID = id;
            Title = title;
        }

    }
}