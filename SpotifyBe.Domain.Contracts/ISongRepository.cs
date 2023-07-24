using SpotifyBe.Domain.Entities;

namespace SpotifyBe.Domain.Contracts
{
    public interface ISongRepository<T>
    {
        Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(string id);
    }
}
