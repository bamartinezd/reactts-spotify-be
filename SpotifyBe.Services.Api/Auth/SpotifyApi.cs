using System.Text;

namespace SpotifyBe.Services.Api.Auth
{
    public class SpotifyApi
    {
        private readonly IConfiguration _configuration;

        public SpotifyApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ClientCredentialsAuthAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string authUrl = _configuration["AppSettings:authUrl"];
                    string apiUrl = _configuration["AppSettings:apiUrl"];
                    string clientId = _configuration["AppSettings:clientId"];
                    string clientSecret = _configuration["AppSettings:clientSecret"];
                    
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
                    
                    var requestData = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials);
                    HttpResponseMessage response = await httpClient.PostAsync(authUrl, requestData);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request exception: {ex.Message}");
                }
            }
        }
    }
}
