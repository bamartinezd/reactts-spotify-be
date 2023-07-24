using Microsoft.AspNetCore.Mvc;
using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;

namespace SpotifyBe.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository<Album> _albumRepository;
        public AlbumController(IAlbumRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByArtistIdAsync(string id)
        {
            var result = await _albumRepository.GetAlbumsByArtistIdAsync(id);

            return result.ToList();
        }
    }
}
