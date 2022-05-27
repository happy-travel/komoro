﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HappyTravel.Komoro.Data;
using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.KomoroContracts.Availabilities;
using HappyTravel.KomoroContracts.Statics;
using HappyTravel.Money.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    [DbContext(typeof(KomoroContext))]
    partial class KomoroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Availabilities.AvailabilityRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<string>("RatePlanCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<RestrictionStatusDetails>("RestrictionStatusDetails")
                        .HasColumnType("jsonb");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<StayDurationDetails>("StayDurationDetails")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("AvailabilityRestrictions", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Availabilities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumberOfAvailableRooms")
                        .HasColumnType("integer");

                    b.Property<int?>("NumberOfBookedRooms")
                        .HasColumnType("integer");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<string>("RatePlanCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Inventories", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.CancellationPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Deadline")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NoShow")
                        .HasColumnType("integer");

                    b.Property<double>("Percentage")
                        .HasColumnType("double precision");

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

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alpha2Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Point>("Coordinates")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Modified")
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

                    b.Property<string>("SupplierCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("CountryId");

                    b.HasIndex("SupplierCode");

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

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<MoneyAmount?>("ExtraAdultSupplement")
                        .HasColumnType("jsonb");

                    b.Property<MoneyAmount?>("InfantSupplement")
                        .HasColumnType("jsonb");

                    b.Property<List<Occupancy>>("MaximumOccupancy")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("Modified")
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

                    b.HasIndex("RoomTypeId");

                    b.HasIndex("StandardMealPlanId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("RoomTypes", (string)null);
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Availabilities.AvailabilityRestriction", b =>
                {
                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.Property", "Property")
                        .WithMany("AvailabilityRestrictions")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Availabilities.Inventory", b =>
                {
                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.Property", "Property")
                        .WithMany("Inventories")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.CancellationPolicy", b =>
                {
                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.Property", "Property")
                        .WithMany("CancellationPolicies")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Property", b =>
                {
                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Room", b =>
                {
                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.Property", "Property")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("HappyTravel.Komoro.Data.Models.Statics.MealPlan", "MealPlan")
                        .WithMany()
                        .HasForeignKey("StandardMealPlanId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("MealPlan");

                    b.Navigation("Property");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HappyTravel.Komoro.Data.Models.Statics.Property", b =>
                {
                    b.Navigation("AvailabilityRestrictions");

                    b.Navigation("CancellationPolicies");

                    b.Navigation("Inventories");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
