using Microsoft.EntityFrameworkCore;
using Music_App.Models;
using Music_App.Models.EntityConfigurations;
using System.ComponentModel;

namespace Music_App.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {
                
        }

        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new SongEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumEntityTypeConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();
        }
    }
}
