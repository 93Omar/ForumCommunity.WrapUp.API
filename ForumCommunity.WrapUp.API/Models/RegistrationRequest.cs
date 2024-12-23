namespace ForumCommunity.WrapUp.API.Models
{
    public class RegistrationRequest
    {
        public int UserId { get; set; }
        public int ForumId { get; set; }
        public string? Nickname { get; set; }
    }
}
