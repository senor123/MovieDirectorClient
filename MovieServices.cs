using MovieDirectorClient.Models;
using System.Net;

namespace MovieDirectorClient
{
    public class MovieServices
    {
        private HttpClient _client;

        public MovieServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<DirectorMovies>> getMovies()
        {
            return await _client.GetFromJsonAsync<List<DirectorMovies>>("https://localhost:7027/api/Movies");
        }

        public async Task<List<Directors>> getDirectorNames()
        {
            return await _client.GetFromJsonAsync<List<Directors>>("https://localhost:7027/api/Directors");

        }
        public async Task<HttpStatusCode> addMovie(MovieCreation newMovie)
        {
            HttpResponseMessage response=await _client.PostAsJsonAsync("https://localhost:7027/api/Movies", newMovie);

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode;
            }
            else
            {
                throw new Exception("Failed to add movie: " + response.ReasonPhrase);
            }
        }

        public async Task<DirectorMovies> updateMovie(MovieCreation movie,int id)
        {
            var response=await _client.PutAsJsonAsync($"https://localhost:7027/api/Movies/{id}/Details", movie);

            return response.Content.ReadFromJsonAsync<DirectorMovies>().Result;
        }

        public async Task deleteMovie(int id)
        {
            var response = await _client.DeleteAsync($"https://localhost:7027/api/Movies/{id}");
        }
    }
}
