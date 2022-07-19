using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCUniverse.Data.Entities
{
    public class CourseEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("Faculty")]
        public int faculty_id {get; set;}
        [Required]
        public string Name {get; set;} = null!;
        [Required]
        public DateTime startTime {get; set;}
        [Required]
        public DateTime endTime {get; set;}
        [Required]
        public DayOfWeek ClassDay {get; set;}
        [Required]
        public int Credits {get; set;}
        [Required]
        public string Building {get; set;} = null!;
        [Required]
        public int RoomNumber {get; set;}
        public virtual List<Student> Students { get; set; } = new List<Student>();
    }

}