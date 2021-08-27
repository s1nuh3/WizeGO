using System.Text.Json.Serialization;

namespace WizeGo.APi.Models
{
    public class JokeDTO
    {
        [JsonPropertyName("setup")]
        public string Start { get; set; }
        [JsonPropertyName("punchline")]
        public string Finish { get; set; }
    }
}