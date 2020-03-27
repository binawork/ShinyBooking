using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShinyBooking.Data;
using ShinyBooking.Dto;
using ShinyBooking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .ThenInclude(am => am.AmenitiesForDisabled)
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
                    MainPhotoUrl = room.Photos.FirstOrDefault(p => p.IsMain)?.PhotoUrl,
                    RoomAddress = address
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
                    roomForReturn.Equipments.Add(equipmentForReturn);
                }

                
                roomsForReturn.Add(roomForReturn);
            }

            return Ok(roomsForReturn);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(string? id)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomAmenitiesForDisabled)
                .ThenInclude(am => am.AmenitiesForDisabled)
                .Include(r => r.RoomActivities)
                .ThenInclude(ra => ra.Activities)
                .Include(r => r.Photos)
                .Include(r => r.RoomAddress)
                .Include(r => r.RoomEquipments)
                .ThenInclude(re => re.Equipment)
                .FirstOrDefaultAsync(i => i.Id == id)
                ;

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
            var roomForReturn = new RoomForReturnRoomDetailsDto
            {
                Id = room.Id,
                Name = room.Name,
                Rating = room.Rating,
                Description = room.Description,
                RoomArrangementsCapabilitiesDescription = room.RoomArrangementsCapabilitiesDescription,
                Price = room.Price,
                Area = room.Area,
                Capacity = room.Capacity,
                ParkingSpace = room.ParkingSpace,
               
                RoomAddress = address
            };
               
                var photos = room.Photos;
                foreach (var photo in photos)
                {
                    var PhotosForReturn = new PhotosForReturnDto
                    {
                        Id = photo.Id,
                        PhotoUrl = photo.PhotoUrl
                    };
                    roomForReturn.Photos.Add(PhotosForReturn);
                }
            
            
                var equipments = room.RoomEquipments.Select(re => re.Equipment);
                foreach (var equipment in equipments)
                {
                    var equipmentForReturn = new EquipmentForReturnDto
                    {
                        Id = equipment.Id,
                        Name = equipment.Name
                    };
                    roomForReturn.Equipments.Add(equipmentForReturn);
                }

                var amenities = room.RoomAmenitiesForDisabled.Select(am => am.AmenitiesForDisabled);
                foreach (var amenity in amenities)
                {
                    var amenitiesForReturn = new AmenitiesForDisabledDto
                    {
                        Id = amenity.Id,
                        Name = amenity.Name
                    };
                    roomForReturn.AmenitiesForDisabled.Add(amenitiesForReturn);
                }

                var activites = room.RoomActivities.Select(ra => ra.Activities);
                foreach (var activity in activites)
                {
                    var activityForReturn = new ActivitiesForReturnDto
                    {
                        Id = activity.Id,
                        Name = activity.Name
                    };
                    roomForReturn.Activities.Add(activityForReturn);
                }

            return Ok(roomForReturn);
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
        public async Task<ActionResult<Room>> PostRoom(RoomToAddDto roomToAdd)
        {


            var newRoom = new Room
            {
                Id = roomToAdd.Id,
                Name = roomToAdd.Name,
                Area = roomToAdd.Area,
                Capacity = roomToAdd.Capacity,
                Description = roomToAdd.Description,
                ParkingSpace = roomToAdd.ParkingSpace,
                Photos = roomToAdd.Photos,
                Price = roomToAdd.Price,
                Rating = 1,
                RoomActivities = roomToAdd.RoomActivities,
                RoomAddress = roomToAdd.RoomAddress
            };
                if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            _context.Rooms.Add(newRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(newRoom.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoom", new { id = newRoom.Id }, newRoom);
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