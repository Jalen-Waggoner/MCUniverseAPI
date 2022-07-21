using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Course
{
    public class CourseUpdate
    {
        [Required]
        public int Id { get; set; }
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
