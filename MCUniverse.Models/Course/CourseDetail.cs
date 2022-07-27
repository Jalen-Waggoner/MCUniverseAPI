using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Course
{

    // Making a course model for a list of details about the courses that the user searches for specifically
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Professor { get; set; }
        public string Name { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string ClassDays { get; set; } = null!;
        public int Credits { get; set; }
        public Season Semester { get; set; }
        public string Building { get; set; } = null!;
        public int RoomNumber { get; set; }
        public int Students { get; set; }
    }
}
