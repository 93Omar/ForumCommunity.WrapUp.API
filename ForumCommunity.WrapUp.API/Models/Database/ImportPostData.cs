namespace ForumCommunity.WrapUp.API.Models.Database
{
    public class ImportPostData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalPages { get; set; }
        public int? LastProcessedPage { get; set; }
        public int TotalRecords { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
