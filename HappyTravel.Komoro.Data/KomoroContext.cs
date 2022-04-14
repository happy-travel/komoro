using HappyTravel.Komoro.Data.Models.Availabilities;
using HappyTravel.Komoro.Data.Models.Statics;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Data;

public class KomoroContext : DbContext
{
    public KomoroContext(DbContextOptions<KomoroContext> options) : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CancellationPolicy>(e =>
        {
            e.ToTable("CancellationPolicies");
            e.HasKey(cp => cp.Id);
            e.HasIndex(cp => cp.PropertyId);
            e.Property(cp => cp.FromDate).IsRequired();
            e.Property(cp => cp.ToDate).IsRequired();
            e.Property(cp => cp.SeasonalityOrEvent);
            e.Property(cp => cp.Deadline).IsRequired();
            e.Property(cp => cp.Percentage).IsRequired();
            e.Property(cp => cp.NoShow).IsRequired();
            e.Property(cp => cp.Created).IsRequired();
            e.Property(cp => cp.Modified).IsRequired();
            e.HasOne(cp => cp.Property).WithMany(p => p.CancellationPolicies).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Country>(e =>
        {
            e.ToTable("Countries");
            e.HasKey(c => c.Id);
            e.Property(c => c.Alpha2Code).IsRequired();
            e.Property(c => c.Name).IsRequired();
            e.Property(c => c.Created).IsRequired();
            e.Property(c => c.Modified).IsRequired();
        });

        builder.Entity<MealPlan>(e =>
        {
            e.ToTable("MealPlans");
            e.HasKey(mp => mp.Id);
            e.Property(mp => mp.Name).IsRequired();
            e.Property(mp => mp.Created).IsRequired();
            e.Property(mp => mp.Modified).IsRequired();
        });

        builder.Entity<Property>(e =>
        {
            e.ToTable("Properties");
            e.HasKey(p => p.Id);
            e.HasIndex(p => p.Code);
            e.HasIndex(p => p.SupplierId);
            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.Address).IsRequired().HasColumnType("jsonb");
            e.Property(p => p.Coordinates).IsRequired();
            e.Property(p => p.Phone).IsRequired();
            e.Property(p => p.StarRating).IsRequired();
            e.Property(p => p.PrimaryContact).IsRequired().HasColumnType("jsonb");
            e.Property(p => p.ReservationEmail).IsRequired();
            e.Property(p => p.CheckInTime).IsRequired();
            e.Property(p => p.CheckOutTime).IsRequired();
            e.Property(p => p.PassengerAge).IsRequired().HasColumnType("jsonb");
            e.Property(p => p.Created).IsRequired();
            e.Property(p => p.Modified).IsRequired();
            e.Navigation(p => p.Rooms);
            e.Navigation(p => p.CancellationPolicies);
            e.Navigation(p => p.AvailabilityRestrictions);
            e.HasOne(p => p.Country).WithMany().IsRequired().OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Room>(e =>
        {
            e.ToTable("Rooms");
            e.HasKey(r => r.Id);
            e.HasIndex(r => r.PropertyId);
            e.HasIndex(r => r.RoomTypeId);
            e.HasIndex(r => r.StandardMealPlanId);
            e.Property(r => r.StandardOccupancy).IsRequired().HasColumnType("jsonb");
            e.Property(r => r.MaximumOccupancy).IsRequired().HasColumnType("jsonb");
            e.Property(r => r.ExtraAdultSupplement).HasColumnType("jsonb"); ;
            e.Property(r => r.ChildSupplement).HasColumnType("jsonb"); ;
            e.Property(r => r.InfantSupplement).HasColumnType("jsonb"); ;
            e.Property(r => r.RatePlans).IsRequired();
            e.Property(r => r.Created).IsRequired();
            e.Property(r => r.Modified).IsRequired();
            e.HasOne(r => r.Property).WithMany(p => p.Rooms).IsRequired().OnDelete(DeleteBehavior.Cascade);
            e.HasOne(r => r.MealPlan).WithMany().IsRequired().OnDelete(DeleteBehavior.SetNull).HasForeignKey(r => r.StandardMealPlanId);
            e.HasOne(r => r.RoomType).WithMany().IsRequired().OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<RoomType>(e =>
        {
            e.ToTable("RoomTypes");
            e.HasKey(rt => rt.Id);
            e.HasIndex(rt => rt.Code);
            e.Property(rt => rt.Name).IsRequired();
            e.Property(rt => rt.Category).IsRequired();
            e.Property(rt => rt.Created).IsRequired();
            e.Property(rt => rt.Modified).IsRequired();
        });

        builder.Entity<AvailabilityRestriction>(e =>
        {
            e.ToTable("AvailabilityRestrictions");
            e.HasKey(ar => ar.Id);
            e.HasIndex(ar => ar.PropertyId);
            e.Property(ar => ar.StartDate).IsRequired();
            e.Property(ar => ar.EndDate).IsRequired();
            e.HasIndex(ar => ar.RoomTypeId);
            e.Property(ar => ar.RatePlanCode).IsRequired();
            e.Property(ar => ar.RestrictionStatusDetails).HasColumnType("jsonb");
            e.Property(ar => ar.StayDurationDetails).HasColumnType("jsonb");
            e.Property(ar => ar.Created).IsRequired();
            e.Property(ar => ar.Modified).IsRequired();
            e.HasOne(ar => ar.Property).WithMany(p => p.AvailabilityRestrictions).IsRequired().OnDelete(DeleteBehavior.Cascade);
            e.HasOne(ar => ar.RoomType).WithMany().IsRequired().OnDelete(DeleteBehavior.SetNull);
        });
    }


    public DbSet<CancellationPolicy> CancellationPolicies { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<MealPlan> MealPlans { get; set; } = null!;
    public DbSet<Property> Properties { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<RoomType> RoomTypes { get; set; } = null!;

    public DbSet<AvailabilityRestriction> AvailabilityRestrictions { get; set; } = null!;
}
