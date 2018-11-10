
using System.ComponentModel.DataAnnotations;

namespace SamMiller.Mumba.Api.Models.Requests
{
    /// <summary>
    /// The Class that defines the behavior of a Registration request
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// The Username of the user
        /// </summary>
        /// <value></value>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        /// <value></value>
        [Required]
        public string Password { get; set; }

    }
}