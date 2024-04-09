using JornadaMilhasApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhasApp.Data.Mappings;

public class TestimonialMap : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.ToTable("Testimonial");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);
        builder.Property(x => x.Comment)
            .IsRequired()
            .HasColumnName("Comment")
            .HasColumnType("NVARCHAR(MAX)")
            .HasMaxLength(1000);
        builder.Property(x => x.Photo)
            .HasColumnName("Photo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
    }
}