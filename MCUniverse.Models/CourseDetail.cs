using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models
{
    public class CourseDetail
    {
        public string Name { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string ClassDays { get; set; } = null!;
        public int Credits { get; set; }
        public string Building { get; set; } = null!;
        public int RoomNumber { get; set; }
    }
}
