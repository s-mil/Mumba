using System;

namespace SamMiller.Mumba.Models.AccountViewModels
{
    /// <summary>
    /// For adding a new User
    /// </summary>
    public class NewAppUser : AppUser
    {
        /// <summary>
        /// The password of the User
        /// </summary>
        public string Password { get; set; }
    }
}