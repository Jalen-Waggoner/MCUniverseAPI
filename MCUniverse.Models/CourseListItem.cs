using MCUniverse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;

namespace MCUniverse.Models
{
    public class CourseListItem
    {
        public string Name { get; set; } = null!;
        public int Credits { get; set; }

        public virtual List<Faculty> Facutly { get; set; } = new List<Faculty>();

        //public string FacName
        //{
        //    get
        //    {

        //        foreach (Rating rating in Ratings)
        //        {
        //            total += rating.Score;
        //        }
        //        return total / Ratings.Count;
        //    }
        //}

        
    }
}
