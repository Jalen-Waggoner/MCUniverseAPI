using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCUniverse.Data.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        public Season Semester { get; set;}
        [Required]
        public string Building {get; set;} = null!;
        [Required]
        public int RoomNumber {get; set;}
        public virtual List<Student> students { get; set; } = new List<Student>();
        public virtual List<Faculty> faculties { get; set; } = new List<Faculty>();
    }
    
    public enum Season
    {
        Fall,
        Spring,
        Summer
    }
}