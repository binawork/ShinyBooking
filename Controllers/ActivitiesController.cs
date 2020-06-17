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
    public class ActivitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
         public async Task<IActionResult> GetActivities()
        {

            var activities = await _context.Activities.ToListAsync();
            var activitiesForReturn = new List<ActivitiesForReturnDto>();

            foreach (var activity in activities)
            {
                var activityForReturn = new ActivitiesForReturnDto

                {
                    Id = activity.Id,
                    Name = activity.Name
                };
                activitiesForReturn.Add(activityForReturn);
            }
            return Ok(activitiesForReturn);

        }
       

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activities>> GetActivities(string id)
        {
            var activities = await _context.Activities.FindAsync(id);

            if (activities == null)
            {
                return NotFound();
            }

            return activities;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivities(string id, Activities activities)
        {
            if (id != activities.Id)
            {
                return BadRequest();
            }

            _context.Entry(activities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitiesExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Activities>> PostActivities(Activities activities)
        {
            _context.Activities.Add(activities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActivitiesExists(activities.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivities", new { id = activities.Id }, activities);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activities>> DeleteActivities(string id)
        {
            var activities = await _context.Activities.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activities);
            await _context.SaveChangesAsync();

            return activities;
        }

        private bool ActivitiesExists(string id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
    }
}
