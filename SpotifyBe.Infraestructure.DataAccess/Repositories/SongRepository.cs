using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using System.Xml.Linq;

namespace SpotifyBe.Infraestructure.DataAccess.Repositories
{
    public class SongRepository : ISongRepository<Song>
    {
        public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(string id)
        {
            var song1 = new Song
            {
                disc_number = 1,
                duration_ms = 85400,
                @explicit = true,
                href = "https://api.spotify.com/v1/tracks/6OmhkSOpvYBokMKQxpIGx2",
                id = "6OmhkSOpvYBokMKQxpIGx2",
                is_local = false,
                name = "Global Warming (feat. Sensato)",
                preview_url = "https://p.scdn.co/mp3-preview/0ce51df079155a323b91642b9f7a19bdebfc6bc1?cid=a4819256614348ae8aead5defa741c51",
                track_number = 1,
                type = "track",
                uri = "spotify:track:6OmhkSOpvYBokMKQxpIGx2"
            };

            var song2 = new Song
            {
                disc_number = 1,
                duration_ms = 207440,
                @explicit = false,
                href = "https://api.spotify.com/v1/tracks/7fmpKF0rLGPnP7kcQ5ZMm7",
                id = "7fmpKF0rLGPnP7kcQ5ZMm7",
                is_local = false,
                name = "Back in Time - featured in Men In Black 3",
                preview_url = "https://p.scdn.co/mp3-preview/f8f0f2ab406a1443d0543e7639d72cf330282a15?cid=a4819256614348ae8aead5defa741c51",
                track_number = 4,
                type = "track",
                uri = "spotify:track:7fmpKF0rLGPnP7kcQ5ZMm7"
            };

            var songs = new List<Song>();
            songs.Add(song1);
            songs.Add(song2);

            return songs;
        }
    }
}
