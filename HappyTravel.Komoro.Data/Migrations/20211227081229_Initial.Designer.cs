﻿// <auto-generated />
using HappyTravel.KomoroContracts.Statics;
using HappyTravel.Money.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    [DbContext(typeof(KomoroContext))]
    [Migration("20211227081229_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.CancellationPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Deadline")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NoShow")
                        .HasColumnType("integer");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<string>("SeasonalityOrEvent")
                        .HasColumnType("text");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("CancellationPolicies", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MealPlans", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Address>("Address")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<TimeSpan>("CheckInTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("CheckOutTime")
                        .HasColumnType("interval");

                    b.Property<Point>("Coordinates")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<PassengerAge>("PassengerAge")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Contact>("PrimaryContact")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("ReservationEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StarRating")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Properties", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<MoneyAmount?>("ChildSupplement")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<MoneyAmount?>("ExtraAdultSupplement")
                        .HasColumnType("jsonb");

                    b.Property<MoneyAmount?>("InfantSupplement")
                        .HasColumnType("jsonb");

                    b.Property<List<Occupancy>>("MaximumOccupancy")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<int>("RatePlans")
                        .HasColumnType("integer");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("StandardMealPlanId")
                        .HasColumnType("integer");

                    b.Property<Occupancy>("StandardOccupancy")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
