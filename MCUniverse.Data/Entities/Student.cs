using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCUniverse.Data.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string OriginCountry { get; set; } = null!;
        public virtual List<CourseEntity> courses { get; set; } = new List<CourseEntity>();
    }

}