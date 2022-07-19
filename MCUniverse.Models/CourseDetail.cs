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
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }
        public DayOfWeek ClassDay { get; set; }
        public int Credits { get; set; }
        public string Building { get; set; } = null!;
        public int RoomNumber { get; set; }
    }
}
