using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.services.Models
{
    public class UserClass : IdentityUser
    {
        [Required]
        public string NPM { get; set; }
        [Required]
        public string PASSWORD { get; set; }
    }
}
