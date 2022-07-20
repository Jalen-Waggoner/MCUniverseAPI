﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } 
        [Required]
        public string Gender { get; set; }
        [Required]
        private DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string OriginCountry { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
