
using Newtonsoft.Json;

namespace apiOef14._6.Models
{
    public class EnqueteEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
