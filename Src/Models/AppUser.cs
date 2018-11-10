using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Models
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; set; }


    }
}