using System;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;


namespace SamMiller.Mumba.Api.Core.Entities
{
    public class List : IEntity<Guid>
    {
        public Guid ID { get; private set; }

        public string Name {get; private set;}

        public List(Guid id, string name)
        {
            Guard.Against.Null(name, nameof(name));

            ID = id;
            Name = name;
        }
    }
}