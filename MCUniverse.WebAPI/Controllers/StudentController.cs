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

//namespace MCUniverse.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly IStudentService _service;
//        public StudentController(IStudentService service)
//        {
//            _service = service;
//        }

//        // GET: api/Student
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
//        {
//          if (_service.Student == null)
//          {
//              return NotFound();
//          }
//            return await _service.Students.ToListAsync();
//        }

//        // GET: api/Studentss/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Students>> GetStudent(int id)
//        {
//          if (_service.Student == null)
//          {
//              return NotFound();
//          }
//            var Student = await _service.Student.FindAsync(id);

//            if (Student == null)
//            {
//                return NotFound();
//            }

//            return Student;
//        }

//        // PUT: api/Student/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutStudent(int id, Student Student)
//        {
//            if (id != Student.Id)
//            {
//                return BadRequest();
//            }

//            _service.Entry(Student).State = EntityState.Modified;

//            try
//            {
//                await _service.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StudentExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Student
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Student>> RegisterStudent([FromBody]StudentRegistration model)
//        {
//            if(!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var registerResult = await _service.RegisterStudentAsync(model);
//            if(registerResult)
//            {
//                return Ok("Student was registered");
//            }
//            return BadRequest("Student could not be registered.");
//        }


//  /*        if (_service.Student == null)
//          {
//              return Problem("Entity set 'MCUniverseWebAPIContext.Student'  is null.");
//          }
//            _service.Student.Add(Student);
//            await _service.SaveChangesAsync();

//            return CreatedAtAction("GetStudent", new { id = Student.Id }, Student);
//        }*/

//        // DELETE: api/Student/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudent(int id)
//        {
//            if (_service.Student == null)
//            {
//                return NotFound();
//            }
//            var Student = await _service.Student.FindAsync(id);
//            if (Student == null)
//            {
//                return NotFound();
//            }

//            _service.Student.Remove(Student);
//            await _service.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool StudentExists(int id)
//        {
//            return (_service.Student?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
