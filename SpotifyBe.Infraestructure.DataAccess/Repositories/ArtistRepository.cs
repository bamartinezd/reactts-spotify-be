
using Newtonsoft.Json;
using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SpotifyBe.Infraestructure.DataAccess.Repositories
{
    public class ArtistRepository : IArtistRepository<Artist>
    {
        private readonly HttpClient _httpClient;

        public ArtistRepository() {
            _httpClient = new HttpClient();
            
        }
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
        public async Task<IEnumerable<Artist>> GetArtistsByIdsAsync(string ids, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spotify.com/v1/artists?ids=" + string.Join(",", ids));

            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<JsonObject>(await response.Content.ReadAsStringAsync());
                return result.artists;
            }

            throw new Exception($"Error getting artists: {response.StatusCode}");
        }
    }

    public class JsonObject
    {
        public IEnumerable<Artist> artists { get; set; }
    }
}
