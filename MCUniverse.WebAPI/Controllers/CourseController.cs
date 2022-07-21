/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCUniverse.Data.Entities;
using MCUniverse.Data;
using MCUniverse.Models.Course;
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

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromForm] CourseCreate newCourse)
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
        public async Task<IActionResult> GetCourseEntities()
        {
            var courses = await _cService.ShowAllCourses();
            return Ok(courses);
        }

       // // GET: api/Course/5
       [HttpGet("{courseId:int}")]
       public async Task<IActionResult> ShowCourseByCourseId([FromRoute] int courseId)
        {
            var course = await _cService.ShowCoursebyCourseIdAsync(courseId);
            return Ok(course);
        }*/

        //GET: api/Course/FacultyId/5
       /*[HttpGet("~/api/course/FacultyId/{facultyId:int}")]
        public async Task<IActionResult> ShowCoursesByFacultyId(int facultyId)
        {
            var courses = await _cService.ShowAllCoursesByFacultyIdAsync(facultyId);
            return Ok(courses);
        }

        // PUT: api/Course
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromForm] CourseUpdate adjCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _cService.UpdateCourseAsync(adjCourse)
                ? Ok("Course was successfully updated!")
                : BadRequest("Course could not be updated");
        }
*/
       // //private bool CourseEntityExists(int id)
       //{
       //     return (_context.Courses?.Any(e => e.id == id)).GetValueOrDefault();
       // } /*
/*  }

        // DELETE: api/Course/5
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int courseId)
        {
            return await _cService.DeleteCourseAsync(courseId)
                ? Ok("Course was successfully deleted")
                : BadRequest("Course could not be deleted");
        }
    }*/
