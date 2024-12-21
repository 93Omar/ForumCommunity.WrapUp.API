using NillForum.WrapUp.API.Models.Database;

namespace NillForum.WrapUp.API.Repositories
{
    public interface IUserRepository
    {
        public Task<int> CreateAsync(User user);
        public Task<bool> LoginAsync(string nickname, string loginToken);
    }
}
