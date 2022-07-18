using System;
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
    public class FacultyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Faculty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyEntity>>> GetFacultyEntity()
        {
          if (_context.Faculties == null)
          {
              return NotFound();
          }
            return await _context.Faculties.ToListAsync();
        }

        // GET: api/Faculty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyEntity>> GetFacultyEntity(int id)
        {
          if (_context.Faculties == null)
          {
              return NotFound();
          }
            var facultyEntity = await _context.Faculties.FindAsync(id);

            if (facultyEntity == null)
            {
                return NotFound();
            }

            return facultyEntity;
        }

        // PUT: api/Faculty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultyEntity(int id, FacultyEntity facultyEntity)
        {
            if (id != facultyEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(facultyEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyEntityExists(id))
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

        // POST: api/Faculty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacultyEntity>> PostFacultyEntity(FacultyEntity facultyEntity)
        {
          if (_context.Faculties == null)
          {
              return Problem("Entity set 'MCUniverseWebAPIContext.FacultyEntity'  is null.");
          }
            _context.Faculties.Add(facultyEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultyEntity", new { id = facultyEntity.Id }, facultyEntity);
        }

        // DELETE: api/Faculty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultyEntity(int id)
        {
            if (_context.Faculties == null)
            {
                return NotFound();
            }
            var facultyEntity = await _context.Faculties.FindAsync(id);
            if (facultyEntity == null)
            {
                return NotFound();
            }

            _context.Faculties.Remove(facultyEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacultyEntityExists(int id)
        {
            return (_context.Faculties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
