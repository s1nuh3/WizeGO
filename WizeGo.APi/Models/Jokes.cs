using System.Text.Json.Serialization;

namespace WizeGo.APi.Models
{
    public partial class Jokes
    {   
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("setup")]
        public string Setup { get; set; }
        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }
    }
}