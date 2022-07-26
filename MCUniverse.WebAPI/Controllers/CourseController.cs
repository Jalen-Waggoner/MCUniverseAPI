using System;
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
        [HttpGet("courseId")]
        public async Task<IActionResult> ShowCourseByCourseId([FromQuery] int courseId)
        {
            var course = await _cService.ShowCoursebyCourseIdAsync(courseId);
            return Ok(course);
        }

        //GET: api/Course/FacultyId/5
        [HttpGet("facultyId")]
        public async Task<IActionResult> ShowCoursesByFacultyId([FromQuery] int facultyId)
        {
            var courses = await _cService.ShowAllCoursesByFacultyIdAsync(facultyId);
            return Ok(courses);
        }

        //GET: api/Course/Credits/3
        [HttpGet("credits")]
        public async Task<IActionResult> ShowCoursesByCredits([FromQuery] int credits)
        {
            var courses = await _cService.ShowAllCoursesByCreditsAsync(credits);
            return Ok(courses);
        }

        //GET: api/Course/Semester/1
        [HttpGet("semester")]
        public async Task<IActionResult> ShowCoursesBySemester([FromQuery] int semester)
        {
            var courses = await _cService.ShowAllCoursesBySemesterAsync(semester);
            return Ok(courses);
        }

        //GET: api/Course/Name/"name"
        [HttpGet("keyword")]
        public async Task<IActionResult> ShowCoursesByName([FromQuery] string keyword)
        {
            var courses = await _cService.ShowCourseByNameAsync(keyword);
            return Ok(courses);
        }

        // PUT: api/Course
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourse([FromQuery] int courseId, [FromForm] CourseUpdate adjCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _cService.UpdateCourseAsync(courseId, adjCourse)
                ? Ok("Course was successfully updated!")
                : BadRequest("Course could not be updated");
        }

        // DELETE: api/Course/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCourse([FromQuery] int courseId)
        {
            return await _cService.DeleteCourseAsync(courseId)
                ? Ok("Course was successfully deleted")
                : BadRequest("Course could not be deleted");
        }

        // GET: api/Course/5
        [HttpGet("students")]
        public async Task<IActionResult> ShowStudentsByCourseId([FromQuery] int courseId)
        {
            var course = await _cService.ShowStudentsbyCourseIdAsync(courseId);
            return Ok(course);
        }
    }
}
