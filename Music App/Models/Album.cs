using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class Album : Entity<int>
    {
        public string Name { get; set; }

        public required ICollection<Song> Songs { get; set; }

        public int ArtistId {  get; set; }

        public required Artist Artist { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
