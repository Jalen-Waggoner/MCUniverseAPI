using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models
{
    public class StudentRegistration
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Username { get; set; }
        [Required]
        [MinLength(7)]
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        [Phone]
        public string PhoneNumber { get; set; }
        public string OriginCountry { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
