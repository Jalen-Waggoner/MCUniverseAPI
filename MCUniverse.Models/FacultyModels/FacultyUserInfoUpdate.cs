﻿using MCUniverse.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.FacultyModels
{
    public class FacultyUserInfoUpdate
    {   
        [Required]
        [MinLength(2, ErrorMessage = "Error: {0} must contain at least {1} characters.")]
        [MaxLength(30, ErrorMessage = "Error: {0} must contain no more than {1} characters.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Error: {0} must contain at least {1} characters.")]
        [MaxLength(30, ErrorMessage = "Error: {0} must contain no more than {1} characters.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
    }
}
