using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCUniverse.Data.Entities;
using MCUniverse.Data;
using MCUniverse.Services.FacultyServices;
using MCUniverse.Models.FacultyModels;

namespace MCUniverse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {

        private readonly IFacultyService _service;

        public FacultyController(IFacultyService service)
        {
            _service = service;
        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> RegisterFaculty([FromForm] FacultyCreate faculty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerResult = await _service.RegisterFacultyAysnc(faculty);
            if (registerResult)
                return Ok("Faculty Memeber was created.");

            return BadRequest("Faculty Member was not created. Check entered information");
        }


        //GET BY ID
        [HttpGet("{facultyId:int}")]
        public async Task<IActionResult> GetFacultyById([FromRoute] int facultyId)
        {
            var facultyDetail = await _service.GetFacultyByIdAsync(facultyId);

            if (facultyDetail == null)
                return NotFound();

            return Ok(facultyDetail);
        }


        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllFaculty()
        {
            var facultyListItem = await _service.GetAllFacultyAsync();

            if (facultyListItem == null)
                return NotFound();

            return Ok(facultyListItem);
        }


        //UPDATE USER INFO
        [HttpPut("{id}/UpdateFacultyInfo")]
        public async Task<IActionResult> UpdateFacultyById([FromForm] FacultyUserInfoUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateFacultyAsync(request)
                ? Ok("Faculty Member has been updated.")
                : BadRequest("Faculty Member could not be updated.");
        }


        //DELETE
        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> DeleteFacultyById(int facultyId)
        {
            return await _service.DeleteFacultyAsync(facultyId)
                ? Ok($"Facutly Memeber {facultyId} was deleted successfully.")
                : BadRequest($"Faculty Memeber {facultyId} could not be deleted.");
        }


        //GET LIST OF COURSES BY FACULTY ID
        [HttpGet("{facultyId:int}/Courses")]
        public async Task<IActionResult> ListCoursesByFacultyId(int facultyId)
        {
            if (!ModelState.IsValid)
                return NotFound(ModelState);
            var courses = await _service.ListCoursesByFacultyIdAsync(facultyId);

            if (courses == null)
                return BadRequest();

            return Ok(courses);
        }


        //UPDATE COURSE OWNER BY COURSE ID AND FACULTY ID
        [HttpPut("AssignCourse")]
        public async Task<IActionResult> AssignCourseToFacultyMemeber(int courseId, int facultyId)
        {
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            var courses = await _service.AssignCourseToFacultyMemeberAsync(courseId, facultyId);

            return Ok("Faculty Member has been changed.");
        }


        //GET BY FIRST NAME OR LAST NAME
        [HttpGet("Search")]
        public async Task<IActionResult> SearchFacultyByName(string search)
        {
            var faculty = await _service.SearchFacultyByNameAsync(search);

            if (faculty == null)
                return NotFound();

            return Ok(faculty);
        }


        //UPDATE FACULTY USERNAME AND PASSWORD
        [HttpPut("{id}/UpdateFacultyLogIn")]
        public async Task<IActionResult> UpdateFacultyLogin([FromForm]FacultyLogInUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateFacultyUserNameAndPasswordAsync(request)
                ? Ok("Faculty User Info has been updated.")
                : BadRequest("Faculty User Info could not be updated.");
        }
    }
}