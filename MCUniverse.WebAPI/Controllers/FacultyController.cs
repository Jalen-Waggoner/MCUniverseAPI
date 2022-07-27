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
        //Route api/Faculty
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
        //Route api/Faculty/1
        [HttpGet("{facultyId:int}")]
        public async Task<IActionResult> GetFacultyById([FromRoute] int facultyId)
        {
            var facultyDetail = await _service.GetFacultyByIdAsync(facultyId);

            if (facultyDetail == null)
                return NotFound();

            return Ok(facultyDetail);
        }


        //GET ALL
        //Route api/Faculty
        [HttpGet]
        public async Task<IActionResult> GetAllFaculty()
        {
            var facultyListItem = await _service.GetAllFacultyAsync();

            if (facultyListItem == null)
                return NotFound();

            return Ok(facultyListItem);
        }


        //UPDATE USER INFO
        //Route api/Faculty/1/UpdateUserInfo
        [HttpPut("{facultyId}/UpdateUserInfo")]
        public async Task<IActionResult> UpdateFacultyUserInfo(int facultyId, [FromForm] FacultyUserInfoUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateFacultyUserInfoAsync(facultyId, request)
                ? Ok("Faculty Member has been updated.")
                : BadRequest("Faculty Member could not be updated.");
        }


        //DELETE
        //Route api/Faculty/1
        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> DeleteFacultyById(int facultyId)
        {
            return await _service.DeleteFacultyAsync(facultyId)
                ? Ok($"Facutly Memeber {facultyId} was deleted successfully.")
                : BadRequest($"Faculty Memeber {facultyId} could not be deleted.");
        }


        //GET LIST OF COURSES BY FACULTY ID
        //Route api/Faculty/1/Courses
        [HttpGet("{facultyId}/Courses")]
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
        //Route api/Faculty/AssignCourse?courseId=1&facultyId=1
        [HttpPut("AssignCourse")]
        public async Task<IActionResult> AssignCourseToFacultyMemeber(int courseId, int facultyId)
        {
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            var courses = await _service.AssignCourseToFacultyMemeberAsync(courseId, facultyId);

            return Ok("Faculty Member has been changed.");
        }


        //GET BY FIRST NAME OR LAST NAME
        //Route api/Faculty/Search?keyword=Nicholas
        [HttpGet("Search")]
        public async Task<IActionResult> SearchFacultyByName(string keyword)
        {
            var faculty = await _service.SearchFacultyByNameAsync(keyword);

            if (faculty == null)
                return NotFound();

            return Ok(faculty);
        }


        //UPDATE FACULTY USERNAME AND PASSWORD
        //Route api/Faculty/1/UpdateLogIn
        [HttpPut("{facultyId}/UpdateLogIn")]
        public async Task<IActionResult> UpdateFacultyLogin(int facultyId, [FromForm]FacultyLogInUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateFacultyLoginAsync(facultyId, request)
                ? Ok("Faculty User Info has been updated.")
                : BadRequest("Faculty User Info could not be updated.");
        }
    }
}