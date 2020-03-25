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
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms
                .Include(r => r.RoomAmenitiesForDisabled)
                .ThenInclude(am=> am.AmenitiesForDisabled)
                .Include(r => r.RoomActivities)
                .ThenInclude(ra => ra.Activities) 
                .Include(r => r.Photos)
                .Include(r => r.RoomAddress)
                .Include(r => r.RoomEquipments)
                .ThenInclude(re => re.Equipment).ToListAsync();
            
            var roomsForReturn = new List<RoomForReturnListOfRoomsDto>();

            foreach (var room in rooms)
            {
                var address = new RoomAddressForReturnDto
                {
                    Id = room.RoomAddress.Id,
                    ApartmentNumber = room.RoomAddress.ApartmentNumber,
                    BuildingNumber = room.RoomAddress.BuildingNumber,
                    City = room.RoomAddress.City,
                    Country = room.RoomAddress.Country,
                    PostalCode = room.RoomAddress.PostalCode,
                    Street = room.RoomAddress.Street,
                    OtherAddressInformation = room.RoomAddress.OtherAddressInformation,
                    PhoneNumber1 = room.RoomAddress.PhoneNumber1,
                    PhoneNumber2 = room.RoomAddress.PhoneNumber2,
                    EmailAddress = room.RoomAddress.EmailAddress,
                    WebPage = room.RoomAddress.WebPage,
                    Directions = room.RoomAddress.Directions

                };
                
                var roomForReturn = new RoomForReturnListOfRoomsDto
                {
                    Id = room.Id,
                    Name = room.Name,
                    Rating = room.Rating,
                    Price = room.Price,
                    Area = room.Area,
                    Capacity = room.Capacity,
                    MainPhotoUrl = room.Photos.FirstOrDefault( p => p.IsMain)?.PhotoUrl,
                    AddressForReturnDto = address
                    
                };

                //add equipment to returned room object
                var equipments = room.RoomEquipments.Select(re => re.Equipment);
                foreach (var equipment in equipments)
                {
                    var equipmentForReturn = new EquipmentForReturnDto
                    {
                        Id = equipment.Id,
                        Name = equipment.Name
                    };
                    roomForReturn.EquipmentsForReturnListDto.Add(equipmentForReturn);
                }

                var amenities = room.RoomAmenitiesForDisabled.Select(am => am.AmenitiesForDisabled);
                foreach (var amenity in amenities)
                {
                    var amenitiesForReturn = new AmenitiesForDisabledDto
                    {
                        Id = amenity.Id,
                        Name = amenity.Name
                    };
                    roomForReturn.AmenitiesForDisabledDto.Add(amenitiesForReturn);
                }
 
               var activites = room.RoomActivities.Select(ra => ra.Activities);
                foreach (var activity in activites)
                {
                    var activityForReturn = new ActivitiesForReturnDto
                    {
                        Id = activity.Id,
                        Name = activity.Name
                    };
                    roomForReturn.ActivitiesForReturnDto.Add(activityForReturn);
                }
                roomsForReturn.Add(roomForReturn);
            }


            return Ok(roomsForReturn);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(string id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
            
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(string id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(room.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(string id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(string id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
