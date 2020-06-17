using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShinyBooking.Data;
using ShinyBooking.Dto;
using ShinyBooking.Models;

namespace ShinyBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesForDisabledController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AmenitiesForDisabledController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AmenitiesForDisableds
        [HttpGet]
          public async Task<IActionResult> GetAmenitiesForDisabled()
        {

            var amenitiesForDisabled = await _context.AmenitiesForDisabled.ToListAsync();
            var amenitiesForDisabledForReturn = new List<AmenitiesForDisabledDto>();

            foreach (var amenityForDisabled in amenitiesForDisabled)
            {
                var amenityForDisabledToReturn = new AmenitiesForDisabledDto

                {
                    Id = amenityForDisabled.Id,
                    Name = amenityForDisabled.Name
                };
                amenitiesForDisabledForReturn.Add( amenityForDisabledToReturn );
            }
            return Ok(amenitiesForDisabledForReturn);

        }

        // GET: api/AmenitiesForDisableds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesForDisabled>> GetAmenitiesForDisabled(string id)
        {
            var amenitiesForDisabled = await _context.AmenitiesForDisabled.FindAsync(id);

            if (amenitiesForDisabled == null)
            {
                return NotFound();
            }

            return amenitiesForDisabled;
        }

        // PUT: api/AmenitiesForDisableds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenitiesForDisabled(string id, AmenitiesForDisabled amenitiesForDisabled)
        {
            if (id != amenitiesForDisabled.Id)
            {
                return BadRequest();
            }

            _context.Entry(amenitiesForDisabled).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesForDisabledExists(id))
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

        // POST: api/AmenitiesForDisableds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AmenitiesForDisabled>> PostAmenitiesForDisabled(AmenitiesForDisabled amenitiesForDisabled)
        {
            _context.AmenitiesForDisabled.Add(amenitiesForDisabled);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AmenitiesForDisabledExists(amenitiesForDisabled.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAmenitiesForDisabled", new { id = amenitiesForDisabled.Id }, amenitiesForDisabled);
        }

        // DELETE: api/AmenitiesForDisableds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AmenitiesForDisabled>> DeleteAmenitiesForDisabled(string id)
        {
            var amenitiesForDisabled = await _context.AmenitiesForDisabled.FindAsync(id);
            if (amenitiesForDisabled == null)
            {
                return NotFound();
            }

            _context.AmenitiesForDisabled.Remove(amenitiesForDisabled);
            await _context.SaveChangesAsync();

            return amenitiesForDisabled;
        }

        private bool AmenitiesForDisabledExists(string id)
        {
            return _context.AmenitiesForDisabled.Any(e => e.Id == id);
        }
    }
}
