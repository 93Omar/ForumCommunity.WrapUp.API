using System.Text.Json.Serialization;

namespace NillForum.WrapUp.API.Models.Forum
{
    public class ForumPost
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("points")]
        public string? Points { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }
}
