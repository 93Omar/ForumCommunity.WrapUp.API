using ForumCommunity.WrapUp.API.Models.Database;

namespace ForumCommunity.WrapUp.API.Repositories
{
    public interface IUserRepository
    {
        public Task<int> CreateAsync(User user);
        public Task<bool> LoginAsync(string nickname, string loginToken);
    }
}
