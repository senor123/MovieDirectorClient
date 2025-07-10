using System.Text.Json.Serialization;

namespace MovieDirectorClient.Models
{
    public record class DirectorMovies
    {
        [property: JsonPropertyName("id")] public  int id { get; set; }

        [property: JsonPropertyName("title")] public string Title { get; set; }

        [property: JsonPropertyName("genre")] public string Action { get; set; }

    }
}
