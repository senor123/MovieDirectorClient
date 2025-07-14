using System.Text.Json.Serialization;

namespace MovieDirectorClient.Models
{
    public class DirectorUpdation
    {
        [property: JsonPropertyName("id")] public int id { get; set; }

        [property: JsonPropertyName("name")] public string Name { get; set; }

        [property: JsonPropertyName("age")] public int Age { get; set; }

        [property: JsonPropertyName("movieIds")] public List<int> MovieIds { get; set; }
    }
}
