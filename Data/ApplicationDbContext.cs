using ShinyBooking.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ShinyBooking.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<RoomAddress> RoomAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            //Modelbuilder for n to n relations Room <-> Equipment
            modelBuilder.Entity<RoomEquipment>()
                .HasKey(re => new {re.RoomId, re.EquipmentId});

            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Room>(re => re.Room)
                .WithMany(r => r.RoomEquipments)
                .HasForeignKey(re => re.RoomId);
            
            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Equipment>(re => re.Equipment)
                .WithMany(r => r.RoomEquipments)
                .HasForeignKey(re => re.EquipmentId);

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

            //Modelbuilder for 1 to n relations for base Photo
            modelBuilder.Entity<Photo>()
                .HasOne<Room>(p => p.Room)
                .WithMany(r => r.Photos)
                .HasForeignKey(p => p.RoomId);
        }
    }
}
