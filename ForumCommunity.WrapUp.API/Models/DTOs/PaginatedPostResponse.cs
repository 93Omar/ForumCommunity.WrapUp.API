using System.Text.Json.Serialization;

namespace ForumCommunity.WrapUp.API.Models.DTOs
{
    public class PaginatedPostResponse
    {
        [JsonPropertyName("pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("total")]
        public int TotalPosts { get; set; }

        [JsonPropertyName("posts")]
        public IEnumerable<ForumPost> Posts { get; set; }

        public PaginatedPostResponse()
        {
            Posts = [];
        }
    }
}
