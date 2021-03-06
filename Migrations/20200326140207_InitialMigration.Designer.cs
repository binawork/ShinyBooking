﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShinyBooking.Data;

namespace ShinyBooking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200326140207_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShinyBooking.Models.Activities", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("ShinyBooking.Models.AmenitiesForDisabled", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AmenitiesForDisabled");
                });

            modelBuilder.Entity("ShinyBooking.Models.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("ShinyBooking.Models.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("ShinyBooking.Models.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("ParkingSpace")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("RoomArrangementsCapabilitiesDescription")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Test")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomActivities", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivitiesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomId", "ActivitiesId");

                    b.HasIndex("ActivitiesId");

                    b.ToTable("RoomActivities");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomAddress", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherAddressInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebPage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique()
                        .HasFilter("[RoomId] IS NOT NULL");

                    b.ToTable("RoomAddresses");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomAmenitiesForDisabled", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AmenitiesForDisabledId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomId", "AmenitiesForDisabledId");

                    b.HasIndex("AmenitiesForDisabledId");

                    b.ToTable("RoomAmenitiesForDisabled");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomEquipment", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EquipmentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("RoomEquipments");
                });

            modelBuilder.Entity("ShinyBooking.Models.Photo", b =>
                {
                    b.HasOne("ShinyBooking.Models.Room", "Room")
                        .WithMany("Photos")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomActivities", b =>
                {
                    b.HasOne("ShinyBooking.Models.Activities", "Activities")
                        .WithMany("RoomActivities")
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShinyBooking.Models.Room", "Room")
                        .WithMany("RoomActivities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomAddress", b =>
                {
                    b.HasOne("ShinyBooking.Models.Room", "Room")
                        .WithOne("RoomAddress")
                        .HasForeignKey("ShinyBooking.Models.RoomAddress", "RoomId");
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomAmenitiesForDisabled", b =>
                {
                    b.HasOne("ShinyBooking.Models.AmenitiesForDisabled", "AmenitiesForDisabled")
                        .WithMany("RoomAmenitiesForDisabled")
                        .HasForeignKey("AmenitiesForDisabledId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShinyBooking.Models.Room", "Room")
                        .WithMany("RoomAmenitiesForDisabled")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShinyBooking.Models.RoomEquipment", b =>
                {
                    b.HasOne("ShinyBooking.Models.Equipment", "Equipment")
                        .WithMany("RoomEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShinyBooking.Models.Room", "Room")
                        .WithMany("RoomEquipments")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
