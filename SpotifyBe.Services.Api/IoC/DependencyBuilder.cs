using SpotifyBe.Domain.Contracts;
using SpotifyBe.Domain.Entities;
using SpotifyBe.Infraestructure.DataAccess.Repositories;

namespace SpotifyBe.Services.Api.IoC
{
    public static class DependencyBuilder
    {
        public static void CofigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IArtistRepository<Artist>, ArtistRepository>();
            services.AddScoped<IAlbumRepository<Album>, AlbumRepository>();
            services.AddScoped<ISongRepository<Song>, SongRepository>();
        }
    }
}
