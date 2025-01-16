using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_App.Data;
using Music_App.Helpers;
using Music_App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            var imageUrl = await FileHelper.UploadImage(song.Image);
            var audioUrl = await FileHelper.UploadFile(song.AudioFile);
            song.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs(int? pageNumber, int? pageSize)
        {
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var songs = await (from song in _dbContext.Songs
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                               }).ToListAsync();
            return Ok(songs.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               where song.IsTrending == true
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                               }).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var songs = await (from song in _dbContext.Songs
                               orderby song.UploadedDate descending
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await (from song in _dbContext.Songs
                               where song.Title.StartsWith(query)
                               select new
                               {
                                   Id = song.Id,
                                   Title = song.Title,
                               }).Take(15).ToListAsync();
            return Ok(songs);
        }
    }
}
