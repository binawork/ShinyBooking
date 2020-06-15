using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShinyBooking.Data;
using ShinyBooking.Dto;
using ShinyBooking.Helpers;
using ShinyBooking.Models;

namespace ShinyBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms
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
                    Street = room.RoomAddress.Street
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
                    RoomAddress = address,
                    Customer = room.Customer
                };



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
        public async Task<IActionResult> GetRoom(string id)
        {
           
            var room = await _context.Rooms
                .Include(r => r.Photos)
                .Include(r => r.RoomAddress)
                .Include(r => r.RoomEquipments)
                .ThenInclude(re => re.Equipment)
                .Include(r => r.RoomActivities)
                .ThenInclude(ra => ra.Activities)
                .Include(r => r.RoomAmenitiesForDisabled)
                .ThenInclude(ram => ram.AmenitiesForDisabled)
             
                .Include(r=> r.Customer)
                .ThenInclude(c=>c.Identity)
                            
                                
                .FirstOrDefaultAsync(r => r.Id == id);

       
               
            if (room == null)
            {
                return NotFound();
            }

            var roomToReturn = _mapper.Map<RoomForReturnDetailsDto>(room);

            return Ok(roomToReturn);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(string id, RoomFromEditFormDto room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var existingRoom = _context.Rooms.FirstOrDefault(r => r.Id == id);
            var existingAddress = _context.RoomAddresses.FirstOrDefault(ra => ra.RoomId == id);

            if (existingRoom != null)
            {
                existingRoom.Name = room.Name;
                existingRoom.Description = room.Description;
                existingRoom.Capacity = room.Capacity;
                existingRoom.Area = room.Area;
                existingRoom.RoomArrangementsCapabilitiesDescription = room.RoomArrangementsCapabilitiesDescription;
                existingRoom.Price = room.Price;
                existingRoom.ParkingSpace = room.ParkingSpace;
                existingRoom.Photos = room.Photos;
                existingRoom.RoomEquipments = room.RoomEquipments;
                existingRoom.RoomAmenitiesForDisabled = room.RoomAmenitiesForDisabled;
                existingRoom.RoomActivities = room.RoomActivities;

                existingAddress.PhoneNumber1 = room.RoomAddress.PhoneNumber1;
                existingAddress.PhoneNumber2 = room.RoomAddress.PhoneNumber2;
                existingAddress.PostalCode = room.RoomAddress.PostalCode;
                existingAddress.Street = room.RoomAddress.Street;
                existingAddress.BuildingNumber = room.RoomAddress.BuildingNumber;
                existingAddress.ApartmentNumber = room.RoomAddress.ApartmentNumber;
                existingAddress.EmailAddress = room.RoomAddress.EmailAddress;


                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            _context.Entry(existingRoom).State = EntityState.Modified;

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

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }


        // POST: api/Rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RoomToAddDto>> PostRoom(RoomToAddDto roomToAdd)
        {

            var responsetoken = JsonConvert.DeserializeObject<ResponseToken>(roomToAdd.Token);

            Customer currentCustomer = _context.Customers.FirstOrDefault(c => c.IdentityId == responsetoken.Id);

            if(roomToAdd.Photos is null) return BadRequest("please provide a photo");

            foreach (var photo in roomToAdd.Photos)
            {
                photo.RoomId = roomToAdd.Id;
            }
            foreach (var equipment in roomToAdd.RoomEquipments)
            {
                equipment.RoomId = roomToAdd.Id;
            }
            foreach (var amenitie in roomToAdd.RoomAmenitiesForDisabled)
            {
                amenitie.RoomId = roomToAdd.Id;
            }
            foreach (var activitie in roomToAdd.RoomActivities)
            {
                activitie.RoomId = roomToAdd.Id;
            }
            roomToAdd.RoomAddress.RoomId = roomToAdd.Id;



            var newRoom = new Room()
            {
                Id = roomToAdd.Id,
                Name = roomToAdd.Name,
                Area = roomToAdd.Area,
                Capacity = roomToAdd.Capacity,
                Description = roomToAdd.Description,
                ParkingSpace = roomToAdd.ParkingSpace,
                Photos = roomToAdd.Photos
                        .Select(x => new Photo() { PhotoUrl = x.PhotoUrl, Id = x.Id, IsMain = x.IsMain, RoomId = x.RoomId })
                        .ToList(),


                Price = roomToAdd.Price,
                Rating = 1,
                RoomActivities = roomToAdd.RoomActivities,
                RoomAddress = roomToAdd.RoomAddress,
                RoomEquipments = roomToAdd.RoomEquipments,
                RoomAmenitiesForDisabled = roomToAdd.RoomAmenitiesForDisabled,
                RoomArrangementsCapabilitiesDescription = roomToAdd.RoomArrangementsCapabilitiesDescription,
                Customer = currentCustomer
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