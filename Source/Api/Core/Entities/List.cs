using System;

using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;


namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The class that defines Lists
    /// </summary>
    public class List : IEntity<Guid>
    {
        /// <summary>
        /// The unique ID of the List
        /// </summary>
        /// <value></value>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the list
        /// </summary>
        /// <value></value>
        public string Name {get; private set;}

        /// <summary>
        /// The constructor for lists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public List(Guid id, string name)
        {
            Guard.Against.Null(name, nameof(name));

            Id = id;
            Name = name;
        }
    }
}