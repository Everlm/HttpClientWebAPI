using Newtonsoft.Json;

namespace Application.Dtos.Category.Response
{
    public class CategoryResponseDto
    {
        public int id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public string image { get; set; }
        public DateTime creationAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
