using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models
{
    public class CourseCreate
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Faculty_id { get; set; }
        [Required]
        public string startTime { get; set; }
        [Required]
        public string endTime { get; set; }
        [Required]
        public string classDays { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public string Building { get; set; } = null!;
        [Required]
        public int roomNumber { get; set; }
    }
}
