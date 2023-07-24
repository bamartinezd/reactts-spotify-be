using Microsoft.AspNetCore.Mvc;
using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using SpotifyBe.Services.Api.Auth;

namespace SpotifyBe.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository<Artist> _artistRepository;

        public ArtistController(IArtistRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetFollowedArtistsAsync()
        {
            var result = await _artistRepository.GetFollowedArtistsAsync();

            return result.ToList();
        }

        [HttpGet("{ids}")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistsByIdsAsync(string ids)
        {
            var result = await _artistRepository.GetArtistsByIdsAsync(ids);

            return result.ToList();
        }
    }
}
