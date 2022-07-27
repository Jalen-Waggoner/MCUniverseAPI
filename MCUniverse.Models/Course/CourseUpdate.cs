using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Course
{
    // Course model with a few properties that the faculty member can change/update about a course
    public class CourseUpdate
    {
        public int FacultyId { get; set; } 
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Building { get; set; } = null!;
        [Required]
        public int RoomNumber { get; set; }
    }
}
