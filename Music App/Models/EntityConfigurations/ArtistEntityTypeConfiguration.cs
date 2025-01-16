using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Music_App.Models.EntityConfigurations
{
    public class ArtistEntityTypeConfiguration : BaseConfiguration<Artist>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(s => s.Id).IsRequired();

            builder.Property(s => s.Name).IsRequired();

            builder
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(s => s.Image);
        }
    }
}
