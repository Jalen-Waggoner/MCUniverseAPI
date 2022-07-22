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
        private readonly AppDbContext _context;

        private readonly IFacultyService _service;

        public FacultyController(IFacultyService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterFaculty([FromBody]FacultyCreate faculty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerResult = await _service.RegisterFacultyAysnc(faculty);
                if (registerResult)
                    return Ok("Faculty Memeber was created.");

            return BadRequest("Faculty Member was not created. Check entered information");
        }



        [HttpGet("{facultyId:int}")]
        public async Task<IActionResult> GetFacultyById([FromRoute] int facultyId)
        {
            var facultyDetail = await _service.GetFacultyByIdAsync(facultyId);

            if (facultyDetail == null)
                return NotFound();
            
            return Ok(facultyDetail);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFaculty()
        {
            var facultyListItem = await _service.GetAllFacultyAsync();

            if (facultyListItem == null)
                return NotFound();

            return Ok(facultyListItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFacultyById([FromBody] FacultyUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateFacultyAsync(request)
                ? Ok("Faculty Member has been updated.")
                : BadRequest("Faculty Member could not be updated.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteFacultyById(int facultyId)
        {
            return await _service.DeleteFacultyAsync(facultyId)
                ? Ok($"Facutly Memeber {facultyId} was deleted successfully.")
                : BadRequest($"Faculty Memeber {facultyId} could not be deleted.");
        }
    }
}