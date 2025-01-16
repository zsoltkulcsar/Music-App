using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class Artist : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Album>? Albums { get; set; }

        public ICollection<Song>? Songs { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
