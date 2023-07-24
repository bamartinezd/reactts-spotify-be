using SpotifyBe.Domain.Entities;

namespace SpotifyBe.Domain.Contracts
{
    public interface IArtistRepository<T> where T : class
    {
        Task<IEnumerable<Artist>> GetFollowedArtistsAsync();
        Task<IEnumerable<Artist>> GetArtistsByIdsAsync(string ids);
    }
}