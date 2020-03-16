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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
