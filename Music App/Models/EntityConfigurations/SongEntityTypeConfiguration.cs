using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Music_App.Models.EntityConfigurations
{
    public class SongEntityTypeConfiguration : BaseConfiguration<Song>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Song> builder)
        {
            builder.Property(s => s.Id).IsRequired();

            builder.Property(s => s.Title).IsRequired();

            builder
                .HasOne(s => s.Artist) 
                .WithMany(a => a.Songs) 
                .HasForeignKey(s => s.ArtistId) 
                .OnDelete(DeleteBehavior.Restrict); 

            builder
                .HasOne(s => s.Album) 
                .WithMany(a => a.Songs) 
                .HasForeignKey(s => s.AlbumId) 
                .OnDelete(DeleteBehavior.SetNull); 

            builder.Property(s => s.Language).HasMaxLength(50); 

            builder.Ignore(s => s.AudioFile);
            builder.Ignore(s => s.Image);
        }
    }
}
