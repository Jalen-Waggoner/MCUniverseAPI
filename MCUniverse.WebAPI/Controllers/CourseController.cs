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


    // Sets route for URL after https://localhost:xxxx/
    // Controller name is course
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {


        // Calls tasks from the IService interface to return the desired outcome from each task
        private readonly ICourseService _cService;
        public CourseController(ICourseService cService)
        {
            _cService = cService;
        }




        // Method to create a new course

        // POST: api/course
        [HttpPost]

        // IActionResult is an interface that connects to the URL
        // [FromForm] allows user to input data into form-data
        public async Task<IActionResult> CreateCourse([FromForm] CourseCreate newCourse)
        {
            // Checks if connection is working properly
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Calls on IService task that creates a new course
            if (await _cService.CreateCourse(newCourse))
            {
                // Gives a 200 response, meaning that process went through
                // If a 200 response is recieved, it should display: Course created successfully
                return Ok("Course created successfully");
            }
            
            // Gives a 404 response, which mean that the process could not be completed due to an error
            return BadRequest("Course could not be created");

        }



        // Method to get all courses

        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetCourseEntities()
        {
            var courses = await _cService.ShowAllCourses();

            // Returns the variable that is a list of courses from the service method
            return Ok(courses);
        }



        // Method to get course by courseId

        // GET: api/Course/courseId
        // query params: courseId = 
        [HttpGet("courseId")]

        // [From Query] allows user to input search parameters in query form
        public async Task<IActionResult> ShowCourseByCourseId([FromQuery] int courseId)
        {
            var course = await _cService.ShowCoursebyCourseIdAsync(courseId);
            return Ok(course);
        }




        // Method to get course(s) by facultyId

        // GET: api/Course/facultyId
        // query params: facultyId =
        [HttpGet("facultyId")]
        public async Task<IActionResult> ShowCoursesByFacultyId([FromQuery] int facultyId)
        {
            var courses = await _cService.ShowAllCoursesByFacultyIdAsync(facultyId);
            return Ok(courses);
        }




        // Method to get course(s) by credits

        // GET: api/Course/credits
        // query params: credits =
        [HttpGet("credits")]
        public async Task<IActionResult> ShowCoursesByCredits([FromQuery] int credits)
        {
            var courses = await _cService.ShowAllCoursesByCreditsAsync(credits);
            return Ok(courses);
        }




        // Method to get course(s) by semester

        // GET: api/Course/semester
        // query params: semester = 
        [HttpGet("semester")]
        public async Task<IActionResult> ShowCoursesBySemester([FromQuery] int semester)
        {
            var courses = await _cService.ShowAllCoursesBySemesterAsync(semester);
            return Ok(courses);
        }





        // Method to get course(s) by keyword

        // GET: api/Course/keyword
        // query params: keyword = 
        [HttpGet("keyword")]
        public async Task<IActionResult> ShowCoursesByName([FromQuery] string keyword)
        {
            var courses = await _cService.ShowCourseByNameAsync(keyword);
            return Ok(courses);
        }





        // Method to update course

        // PUT: api/Course/update
        // query params: courseId =
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





        // Method to delete a course

        // DELETE: api/Course/delete
        // query params: courseId =
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCourse([FromQuery] int courseId)
        {
             return await _cService.DeleteCourseAsync(courseId)
                ? Ok("Course was successfully deleted")
                : BadRequest("Course could not be deleted");
        }






        // Method to show list of students in a course

        // GET: api/Course/students
        // query params: courseId = 
        [HttpGet("students")]
        public async Task<IActionResult> ShowStudentsByCourseId([FromQuery] int courseId)
        {
            var course = await _cService.ShowStudentsbyCourseIdAsync(courseId);
            return Ok(course);
        }
    }
}
