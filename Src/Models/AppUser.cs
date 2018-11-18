using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Models
{
    /// <summary>
    /// The User of the application
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
    }
}