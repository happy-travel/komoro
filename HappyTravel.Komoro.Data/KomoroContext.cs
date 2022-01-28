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
            e.HasKey(p => p.Id);
            e.HasIndex(p => p.PropertyId);
            e.Property(p => p.FromDate).IsRequired();
            e.Property(p => p.ToDate).IsRequired();
            e.Property(p => p.SeasonalityOrEvent);
            e.Property(p => p.Deadline).IsRequired();
            e.Property(p => p.Percentage).IsRequired();
            e.Property(p => p.NoShow).IsRequired();
            e.Property(p => p.Created).IsRequired();
            e.Property(p => p.Modified).IsRequired();
            e.HasOne(p => p.Property).WithMany(p => p.CancellationPolicies).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<MealPlan>(e =>
        {
            e.ToTable("MealPlans");
            e.HasKey(p => p.Id);
            e.Property(p => p.Name).IsRequired();
            e.Property(r => r.Created).IsRequired();
            e.Property(r => r.Modified).IsRequired();
        });

        builder.Entity<Property>(e =>
        {
            e.ToTable("Properties");
            e.HasKey(p => p.Id);
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
            e.HasKey(p => p.Id);
            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.Category).IsRequired();
            e.Property(r => r.Created).IsRequired();
            e.Property(r => r.Modified).IsRequired();
        });
    }


    public DbSet<CancellationPolicy> CancellationPolicies { get; set; } = null!;
    public DbSet<MealPlan> MealPlans { get; set; } = null!;
    public DbSet<Property> Properties { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<RoomType> RoomTypes { get; set; } = null!;
}
