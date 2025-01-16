using Microsoft.EntityFrameworkCore;
using Music_App.Models;

namespace Music_App.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {
                
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "You got gold",
                    Language = "en",
                },
                new Song
                {
                    Id = 2,
                    Title = "O O O",
                    Language = "fr"
                },
                new Song
                {
                    Id = 3,
                    Title = "Bella Ciao",
                    Language = "it"
                }
                );
        }
    }
}
