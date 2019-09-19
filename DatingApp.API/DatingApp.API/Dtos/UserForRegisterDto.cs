using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "You must specify a username between 5 and 30 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "You must specify a password between 5 and 100 characters")]
        public string Password { get; set; }
    }
}
