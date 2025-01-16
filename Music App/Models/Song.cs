using System.ComponentModel.DataAnnotations.Schema;

namespace Music_App.Models
{
    public class Song : Entity<int>
    {
        public required string Title { get; set; }

        public DateTime UploadedDate { get; set; }

        public string? Language { get; set; }

        public int ArtistId {  get; set; }

        public Artist? Artist { get; set; }

        public int? AlbumId { get; set; }

        public Album? Album { get; set; }

        public bool IsTrending {  get; set; }

        [NotMapped]
        public IFormFile AudioFile { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
