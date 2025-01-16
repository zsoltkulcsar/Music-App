using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Music_App.Models.EntityConfigurations
{
    internal sealed class AlbumEntityTypeConfiguration : BaseConfiguration<Album>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Album> builder)
        {
            builder.Property(a => a.Id).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(a =>a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(s => s.Image);
        }
    }
}
