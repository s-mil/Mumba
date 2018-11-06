using System;


namespace SamMiller.Mumba.Api.Core.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public User(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

    }
}