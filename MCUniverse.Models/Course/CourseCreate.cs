using MCUniverse.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Course
{
    public class CourseCreate
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string ClassDays { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public Season Semester { get; set; }
        [Required]
        public string Building { get; set; } = null!;
        [Required]
        public int RoomNumber { get; set; }
    }
}
