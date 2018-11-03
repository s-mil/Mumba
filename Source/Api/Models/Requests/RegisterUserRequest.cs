
using System.ComponentModel.DataAnnotations;

namespace SamMiller.Mumba.Api.Models.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}