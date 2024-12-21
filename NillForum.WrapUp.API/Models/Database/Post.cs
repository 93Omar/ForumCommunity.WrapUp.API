namespace NillForum.WrapUp.API.Models.Database
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Points { get; set; }
        public string? Content { get; set; }
        public string? TopicName { get; set; }
        public string? SectionName { get; set; }
    }
}
