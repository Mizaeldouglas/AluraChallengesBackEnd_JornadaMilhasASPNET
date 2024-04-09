using JornadaMilhasApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhasApp.Data.Mappings;

public class DestinyMap: IEntityTypeConfiguration<Destiny>
{
    public void Configure(EntityTypeBuilder<Destiny> builder)
    {
        builder.ToTable("Destiny");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(18,2)");
        
        builder.Property(x => x.Photo)
            .IsRequired()
            .HasColumnName("Photo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.PhotoTwo)
            .IsRequired()
            .HasColumnName("PhotoTwo")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.Property(x => x.Meta)
            .IsRequired()
            .HasColumnName("Meta")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);
    }
}