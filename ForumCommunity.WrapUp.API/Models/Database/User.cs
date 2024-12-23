namespace ForumCommunity.WrapUp.API.Models.Database
{
    public class User
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string? Nickname { get; set; }
        public string? LoginToken { get; set; }
    }
}
