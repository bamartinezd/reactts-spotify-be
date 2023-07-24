
using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SpotifyBe.Infraestructure.DataAccess.Repositories
{
    public class ArtistRepository : IArtistRepository<Artist>
    {
        public async Task<IEnumerable<Artist>> GetFollowedArtistsAsync()
        {
            var artist1 = new Artist {
                genres = new List<string> { "canadian electronic", "complextro", "edm", "electro house", "pop dance", "progressive house" },
                id = "2CIMQHirSU0MQqyYHq0eOx",
                name = "deadmau5",
                popularity = 66,
                type = "artist",
                uri = "spotify:artist:2CIMQHirSU0MQqyYHq0eOx"
            };
            var artist2 = new Artist
            {
                genres = new List<string> { "edm", "pop", "pop dance" },
                id = "1vCWHaC5f2uS3yhpwWbIA6",
                name = "Avicii",
                popularity = 79,
                type = "artist",
                uri = "spotify:artist:1vCWHaC5f2uS3yhpwWbIA6"
            };

            var artists = new List<Artist>();
            artists.Add(artist1);
            artists.Add(artist2);

            return artists;
        }
        public async Task<IEnumerable<Artist>> GetArtistsByIdsAsync(string ids)
        {
            var artist1 = new Artist
            {
                genres = new List<string> { "canadian electronic", "complextro", "edm", "electro house", "pop dance", "progressive house" },
                id = "2CIMQHirSU0MQqyYHq0eOx",
                name = "deadmau5",
                popularity = 66,
                type = "artist",
                uri = "spotify:artist:2CIMQHirSU0MQqyYHq0eOx"
            };
            var artist2 = new Artist
            {
                genres = new List<string> { "edm", "pop", "pop dance" },
                id = "1vCWHaC5f2uS3yhpwWbIA6",
                name = "Avicii",
                popularity = 79,
                type = "artist",
                uri = "spotify:artist:1vCWHaC5f2uS3yhpwWbIA6"
            };

            var artists = new List<Artist>();
            artists.Add(artist1);
            artists.Add(artist2);

            return artists;
        }
    }
}
