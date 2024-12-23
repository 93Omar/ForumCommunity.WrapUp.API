namespace ForumCommunity.WrapUp.API.Models
{
    public class VerifyTokenRequest
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
