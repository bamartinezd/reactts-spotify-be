using SpotifyBe.Domain.Entities;

namespace SpotifyBe.Domain.Contracts
{
    public interface IAlbumRepository<T>
    {
        Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(string id);
    }
}
