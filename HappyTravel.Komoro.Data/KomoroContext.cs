using HappyTravel.Komoro.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Data;

public class KomoroContext : DbContext
{
    public KomoroContext(DbContextOptions<KomoroContext> options) : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Accommodation>(e =>
        {
            e.ToTable("Accommodations");
            e.HasKey(s => s.Id);
            e.Property(s => s.Name).IsRequired();
            e.Property(s => s.Created).IsRequired();
            e.Property(s => s.Modified);
        });
    }


    public DbSet<Accommodation> Suppliers { get; set; } = null!;
}
