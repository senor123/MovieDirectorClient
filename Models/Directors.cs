using System.Text.Json.Serialization;

namespace MovieDirectorClient.Models
{
    public record class Directors
    {
        [property:JsonPropertyName("id")] public int Id { get; set; }

        [property: JsonPropertyName("name")] public string Name { get; set; }

        [property:JsonPropertyName("age")] public int Age { get; set; }

        [property:JsonPropertyName("movies")] public List<MovieCreation> Movies { get; set; }


    }
}
