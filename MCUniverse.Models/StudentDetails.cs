using MCUniverse.Data.Entities;
using System;
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
        public string FullName { get; set; } 
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OriginCountry { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
