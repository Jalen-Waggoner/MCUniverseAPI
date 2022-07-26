using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCUniverse.Data.Entities
{
    // Making courseEntity table for database with properties/columns
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // Making foreign key to Faculties table to access data
        [ForeignKey(nameof(faculty))]
        public int FacultyId { get; set; }
        public Faculty faculty { get; set; }

        [Required]
        public string Name {get; set;} = null!;
        [Required]
        public string StartTime {get; set;}
        [Required]
        public string EndTime {get; set;}
        [Required]
        public string ClassDays {get; set;}
        [Required]
        public int Credits {get; set;}

        // Making semester an enum
        [Required]
        public int Semester { get; set;}
        [Required]
        public string Building {get; set;} = null!;
        [Required]
        public int RoomNumber {get; set;}

        // Making virtual list to make a junction table for a many to many relationship between the Courses and Students tables
        public virtual List<Student> students { get; set; } = new List<Student>();
    }
}

