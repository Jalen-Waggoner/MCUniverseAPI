﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCUniverse.Data.Entities;
using MCUniverse.Data;

namespace MCUniverse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCourseEntity()
        {
          if (_context.Courses == null)
          {
              return NotFound();
          }
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseEntity>> GetCourseEntity(int id)
        {
          if (_context.Courses == null)
          {
              return NotFound();
          }
            var courseEntity = await _context.Courses.FindAsync(id);

            if (courseEntity == null)
            {
                return NotFound();
            }

            return courseEntity;
        }

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseEntity(int id, CourseEntity courseEntity)
        {
            if (id != courseEntity.id)
            {
                return BadRequest();
            }

            _context.Entry(courseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseEntity>> PostCourseEntity(CourseEntity courseEntity)
        {
          if (_context.Courses == null)
          {
              return Problem("Entity set 'MCUniverseWebAPIContext.CourseEntity'  is null.");
          }
            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseEntity", new { id = courseEntity.id }, courseEntity);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseEntity(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var courseEntity = await _context.Courses.FindAsync(id);
            if (courseEntity == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseEntityExists(int id)
        {
            return (_context.Courses?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}