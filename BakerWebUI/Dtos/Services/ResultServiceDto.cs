using Newtonsoft.Json; // Bunu eklemeyi unutma

namespace BakerWebUI.Dtos.Services
{
    public class ResultServiceDto
    {
        [JsonProperty("serviceId")]
        public int ServiceId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}