﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityWebSite.Models.ViewModels {
    public class AdminRegisterViewModel {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public List<string> Roles { get; set; } 
    }
}