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
using Microsoft.AspNetCore.Authorization;
using MCUniverse.Services.Token;
using MCUniverse.Models.Token;

namespace MCUniverse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ITokenService _tokenService;
        public StudentsController(IStudentService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        // Get All Student
        /* We have a couple of Get endpoints to our Student Controller to read from our Student table.
         * In this method, we will return all Students from the database as an OK (200) response
         * /*/

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }


        // Get Student By Id

        /* we are using async method called GetStudentById that also returns an IActionResult.Over here, our GetStudentById method will
        * take in an Id as an integer parameter and use that to find and return a specific student.
        */

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var students = await _service.GetStudentByIdAsync(id);
        return Ok(students);

        }

        // Token Request

        [HttpPost("~/api/TokenService")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password.");

            return Ok(tokenResponse);

        }


        // Enrolling Student By Id

        [HttpPost("EnrollStudent/{StudentId}/{CourseId}")]
        public async Task<IActionResult> EnrollingStudentById([FromRoute] int StudentId, int CourseId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courses = await _service.EnrollingStudentById(StudentId, CourseId);
            if (courses == false)
                return NotFound("Invalid request.");

            return Ok("Student successfully enrolled.");
        }

        // Update Student By Id

        /* To update a Student, we need a PUT endpoint. We are adding a method called Update Student By Id that takes in a Student Update 
         * model and Id as parameters.
         * 
         */



        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentById([FromBody] StudentUpdate Student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return await _service.UpdateStudentByIdAsync(Student)
                 ? Ok("Student was updated.")
                 : BadRequest(ModelState);
        }

        //Get Student By Email

        [HttpGet("Email/{email}")]
        public async Task<IActionResult> GetStudentByEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = await _service.GetStudentByEmailAsync(email);
            return Ok(students);

        }

        //Get Student By Username

        [HttpGet("UserName/{username}")]
        public async Task<IActionResult> GetStudentByUsername([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = await _service.GetStudentByUsernameAsync(username);
            return Ok(students);
        }

        //STUDENT REGISTRATION

        /*We are using an async method called Student Registration that returns an IActionResult.
        IActionResult is an interface which HTTP Action Results follow-these results will contain an HTTP status code,
        and/or either some data or an error message.
        /* We are using the StudentRegistration model we created to represent our form data from incoming POST request. We should be getting all 
        the information that's listed in our StudentRegistration model.As we already know that the ID is added by EntityFramework so a POST 
        request doesn't need to include one. */

        // ModelState is a Controller property we are using to determine if the data being added is valid:
        // If the data is not valid, then we want to return a Bad Request (400) error, along with the ModelState,
        // which will contain information about why the data is not valid.


        // If the data is valid, we want to add it to our database 
        // After we save the updates to the database, we can return an OK student was registered


        // POST: api/Student
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.RegisterStudentAsync(model);
            if (registerResult)
            {
                return Ok("Student was registered");
            }
            return BadRequest("Student could not be registered.");
        }

        //Delete Student By Id

        // DELETE: api/Student/5
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentById([FromRoute]int studentId)
        {
        
            return await _service.DeleteStudentByIdAsync(studentId)
                ? Ok($"Student {studentId} was deleted sucessfully.")
                : BadRequest($"Note{studentId} could not be deleted.");
        }

        // Get Course Enrollment By Id
        // CourseEnrollment
        [HttpGet("StudentId/{studentId}")]
        public async Task<IActionResult> GetCourseEnrollmentById([FromRoute] int studentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = await _service.GetCourseEnrollmentByIdAsync(studentId);
            return Ok(students);

        }
       
        /*
               [Authorize]
                [HttpGet("{studentId:int}")]
                public async Task<IActionResult> GetById([FromRoute] int studentId)
                {
                    var student = await _service.GetStudentByIdAsync(studentId);

                    return Ok(student);
                }*/

    }
    }

