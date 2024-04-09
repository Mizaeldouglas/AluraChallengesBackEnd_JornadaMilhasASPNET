using JornadaMilhasApp.Data.Mappings;
using JornadaMilhasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhasApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Destiny> Destinies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TestimonialMap());
        modelBuilder.ApplyConfiguration(new DestinyMap());
    }
}