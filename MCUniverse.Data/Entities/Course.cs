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
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Faculty))]
        public int Faculty_id {get; set;}
        public Faculty Faculty { get; set; }
        [Required]
        public string Name {get; set;} = null!;
        [Required]
        public string startTime {get; set;}
        [Required]
        public string endTime {get; set;}
        [Required]
        public string classDays {get; set;}
        [Required]
        public int Credits {get; set;}
        [Required]
        public string Building {get; set;} = null!;
        [Required]
        public int roomNumber {get; set;}
        public virtual List<Student> students { get; set; } = new List<Student>();
    }
    
}