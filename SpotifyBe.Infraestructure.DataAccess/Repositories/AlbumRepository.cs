using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using System;
using System.Xml.Linq;

namespace SpotifyBe.Infraestructure.DataAccess.Repositories
{
    public class AlbumRepository : IAlbumRepository<Album>
    {
        public async Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(string id)
        {
            var album1 = new Album { 
                album_group = "album",
                album_type = "album",
                href = "https://api.spotify.com/v1/albums/6qLtYwWznL4G40mJXVmy2f",
                id = "6qLtYwWznL4G40mJXVmy2f",
                name = "Grandes Éxitos",
                release_date = "2022-05-06",
                release_date_precision = "day",
                total_tracks = 30,
                type = "album",
                uri = "spotify:album:6qLtYwWznL4G40mJXVmy2f"
            };

            var album2 = new Album {
                album_group = "album",
                album_type = "album",
                href = "https://api.spotify.com/v1/artists/5LCDv4TvYRQD5ehflOBEh4",
                id = "5LCDv4TvYRQD5ehflOBEh4",
                name = "Dos Generaciones",
                release_date = "2001-11-16",
                release_date_precision = "day",
                total_tracks = 13,
                type = "album",
                uri = "spotify:album:3ZTB4ZliTvEHElJjCjUPzH"
            };

            var albums = new List<Album>();
            albums.Add(album1);
            albums.Add(album2);

            return albums;
        }
    }
}
