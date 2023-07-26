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
        private readonly SpotifyAuthClient _spotifyAuthClient;

        public ArtistController(IArtistRepository<Artist> artistRepository, SpotifyAuthClient spotifyAuthClient)
        {
            _artistRepository = artistRepository;
            _spotifyAuthClient = spotifyAuthClient;
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
            SpotifyAuthToken auth = await _spotifyAuthClient.GetTokenAsync() ;
            var result = await _artistRepository.GetArtistsByIdsAsync(ids,auth.access_token);

            return result.ToList();
        }
    }
}
