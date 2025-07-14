using Microsoft.AspNetCore.Mvc;
using MovieDirectorClient.Models;

namespace MovieDirectorClient
{
    public class DirectorServices
    {
        private HttpClient _httpClient;

        public DirectorServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Directors>> getDirectorNames()
        {
            return await _httpClient.GetFromJsonAsync<List<Directors>>("https://localhost:7027/api/Directors");

        }
        
        public async Task<HttpResponseMessage> addDirector(Directors d)
        {
            return await _httpClient.PostAsJsonAsync("https://localhost:7027/api/Directors",d);
        }

        public async Task<HttpResponseMessage> deleteDirector(int id)
        {
            return await _httpClient.DeleteAsync($"https://localhost:7027/api/Directors/{id}");

        }

        public async Task<HttpResponseMessage> updateDirector(DirectorUpdation director,int id)
        {
            return await _httpClient.PutAsJsonAsync($"https://localhost:7027/api/Directors/{id}", director);

        }
    }
}
