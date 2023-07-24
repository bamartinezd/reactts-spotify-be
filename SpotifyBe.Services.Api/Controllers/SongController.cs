using Microsoft.AspNetCore.Mvc;
using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;

namespace SpotifyBe.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository<Song> _songRepository;
        public SongController(ISongRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByAlbumIdAsync(string id)
        {
            var result = await _songRepository.GetSongsByAlbumIdAsync(id);

            return result.ToList();
        }
    }
}
