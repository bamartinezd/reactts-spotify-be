using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SpotifyBe.Services.Api.Auth
{
    public class SpotifyAuthClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public SpotifyAuthClient(string apiUrl, string clientId, string clientSecret)
        {
            _apiUrl = apiUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;

            _httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}")));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YTQ4MTkyNTY2MTQzNDhhZThhZWFkNWRlZmE3NDFjNTE6ODViZTgzN2UyMzFhNDRmMjgxNDQ5MTRmYTgyOGQzYjU=");
        }

        public async Task<SpotifyAuthToken> GetTokenAsync()
        {
            try
            {
                var requestData = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}/token", requestData);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<SpotifyAuthToken>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }


    }

    public class SpotifyAuthToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
