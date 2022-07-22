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
        public StudentsController(IStudentService service)
        {
            _service = service;
            _tokenService = TokenService;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = await _service.GetStudentByIdAsync(id);
            return Ok(students);

        }

        [HttpPost("~/api/TokenService")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password.");

            return Ok(tokenResponse);

        }





        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(StudentUpdate Student)
        {
           if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return await _service.UpdateStudentByIdAsync(Student)
                 ? Ok()
                 : BadRequest(ModelState);
        }

        // POST: api/Student
        [HttpPost("Register")]
        public async Task<ActionResult<Student>> RegisterStudent([FromBody] StudentRegistration model)
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


        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int studentId)
        {
        
            return await _service.DeleteStudentByIdAsync(studentId)
                ? Ok($"Student {studentId} was deleted sucessfully.")
                : BadRequest($"Note{studentId} could not be deleted.");
        }

       [Authorize]
        [HttpGet("{studentId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int studentId)
        {
            var student = await _service.GetStudentByIdAsync(studentId);
        }

     }
    }

