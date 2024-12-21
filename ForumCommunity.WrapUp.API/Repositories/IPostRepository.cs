using ForumCommunity.WrapUp.API.Models.Database;

namespace ForumCommunity.WrapUp.API.Repositories
{
    public interface IPostRepository
    {
        public Task<int> CreateAsync(Post post);
        public Task CreateBulkAsync(IEnumerable<Post> posts);
        public Task<IEnumerable<Post>> GetAllAsync();
        public Task<IEnumerable<Post>> GetAllByUserIdAsync(int userId);
        public Task<IEnumerable<Post>> GetAllByUserIdAndBetweenDateAsync(int userId, DateTime dateFrom, DateTime dateTo);
    }
}
