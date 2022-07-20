using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCUniverse.Data.Entities;
using MCUniverse.Data;
using MCUniverse.Models;
using MCUniverse.Services;

namespace MCUniverse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _cService;
        public CourseController(ICourseService cService)
        {
            _cService = cService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseCreate newCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cService.CreateCourse(newCourse))
            {
                return Ok("Course created successfully");
            }
            return BadRequest("Course could not be created");

        }

        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetCourseEntity()
        {
            var courses = await _cService.ShowAllCourses();
            return Ok(courses);
        }

       // // GET: api/Course/5
       [HttpGet("{id}")]
       public async Task<IActionResult> ShowCourseById([FromRoute] int id)
        {
            var course = await _cService.ShowCoursebyId(id);
            return Ok(course);
        }

       

       // // PUT: api/Course/5
       // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [HttpPut("{id}")]
       // public async Task<IActionResult> PutCourseEntity(int id, CourseEntity courseEntity)
       // {
       //     if (id != courseEntity.id)
       //     {
       //         return BadRequest();
       //     }

       //     _context.Entry(courseEntity).State = EntityState.Modified;

       //     try
       //     {
       //         await _context.SaveChangesAsync();
       //     }
       //     catch (DbUpdateConcurrencyException)
       //     {
       //         if (!CourseEntityExists(id))
       //         {
       //             return NotFound();
       //         }
       //         else
       //         {
       //             throw;
       //         }
       //     }

       //     return NoContent();
       // }

       // // POST: api/Course
       // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        

       // // DELETE: api/Course/5
       // [HttpDelete("{id}")]
       // //public async Task<IActionResult> DeleteCourseEntity(int id)
       // //{
       // //    if (_context.Courses == null)
       // //    {
       // //        return NotFound();
       // //    }
       // //    var courseEntity = await _context.Courses.FindAsync(id);
       // //    if (courseEntity == null)
       // //    {
       // //        return NotFound();
       // //    }

       // //    _context.Courses.Remove(courseEntity);
       // //    await _context.SaveChangesAsync();

       // //    return NoContent();
       // //}

       // //private bool CourseEntityExists(int id)
       //{
       //     return (_context.Courses?.Any(e => e.id == id)).GetValueOrDefault();
       // } 
    }
}
