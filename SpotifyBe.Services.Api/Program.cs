using SpotifyBe.Services.Api.Auth;
using SpotifyBe.Services.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DependencyInjection();
builder.Services.CofigureCors();

builder.Services.AddScoped<SpotifyAuthClient>(provider => new SpotifyAuthClient(builder.Configuration["AppSettings:apiUrl"], builder.Configuration["AppSettings:clientId"], builder.Configuration["AppSettings:clientSecret"]));

//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
