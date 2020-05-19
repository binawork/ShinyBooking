using ShinyBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShinyBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers {get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }

        public DbSet<RoomAmenitiesForDisabled> RoomAmenitiesForDisabled {get;set;}
        public DbSet<RoomActivities> RoomActivities {get; set;}
        public DbSet<Photo> Photos { get; set; }

        public DbSet<RoomAddress> RoomAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            //Modelbuilder for n to n relations Room <-> Equipment
            modelBuilder.Entity<RoomEquipment>()
                .HasKey(re => new {re.RoomId, re.EquipmentsId});

            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Room>(re => re.Room)
                .WithMany(r => r.RoomEquipments)
                .HasForeignKey(re => re.RoomId);
            
            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Equipment>(re => re.Equipment)
                .WithMany(r => r.RoomEquipments)
                .HasForeignKey(re => re.EquipmentsId);

            //Modelbuilder for n to n relations Room <-> Activities
            modelBuilder.Entity<RoomActivities>()
                .HasKey(re => new {re.RoomId, re.ActivitiesId});

            modelBuilder.Entity<RoomActivities>()
                .HasOne<Room>(re => re.Room)
                .WithMany(r => r.RoomActivities)
                .HasForeignKey(re => re.RoomId);
            
            modelBuilder.Entity<RoomActivities>()
                .HasOne<Activities>(re => re.Activities)
                .WithMany(r => r.RoomActivities)
                .HasForeignKey(re => re.ActivitiesId);

            //Modelbuilder for n to n relations Room <-> AmenitiesForDisabled
            modelBuilder.Entity<RoomAmenitiesForDisabled>()
                .HasKey(re => new {re.RoomId, re.AmenitiesForDisabledId});

            modelBuilder.Entity<RoomAmenitiesForDisabled>()
                .HasOne<Room>(re => re.Room)
                .WithMany(r => r.RoomAmenitiesForDisabled)
                .HasForeignKey(re => re.RoomId);
            
            modelBuilder.Entity<RoomAmenitiesForDisabled>()
                .HasOne<AmenitiesForDisabled>(re => re.AmenitiesForDisabled)
                .WithMany(r => r.RoomAmenitiesForDisabled)
                .HasForeignKey(re => re.AmenitiesForDisabledId);


            //Modelbuilder for 1 to n relations for base Photo
            modelBuilder.Entity<Photo>()
                .HasOne<Room>(p => p.Room)
                .WithMany(r => r.Photos)
                .HasForeignKey(p => p.RoomId);
        }
    }
}
