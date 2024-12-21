using ForumFree.NET;
using NillForum.WrapUp.API.Models.Database;
using NillForum.WrapUp.API.Models.Forum;
using NillForum.WrapUp.API.Repositories;

namespace NillForum.WrapUp.API.Services
{
    public class PostImportService
    {
        private readonly IPostImportRepository _postImportRepository;
        private readonly IPostRepository _postRepository;
        private readonly ForumFreeClient _forumFreeClient;

        public PostImportService(IPostImportRepository postImportRepository, ForumFreeClient forumFreeClient, IPostRepository postRepository)
        {
            _postImportRepository = postImportRepository;
            _forumFreeClient = forumFreeClient;
            _postRepository = postRepository;
        }

        public async Task ImportAsync(int userId)
        {
            HttpResponseMessage responseMessages = await _forumFreeClient.GetPostsByUserId(userId, 1);
            PaginatedPostResponse? postResponse = await responseMessages.Content.ReadFromJsonAsync<PaginatedPostResponse>();

            if (postResponse is null)
            {
                await _postImportRepository.InitImportAsync(userId, 0, 0, ImportStatus.Failed);
                return;
            }

            int importId = await _postImportRepository.InitImportAsync(userId, postResponse.TotalPages, postResponse.TotalPosts);

            List<Post> posts = new();
            int lastProcessedPage = 1;

            for (int i = 1; i <= postResponse!.TotalPages; i++)
            {
                responseMessages = await _forumFreeClient.GetPostsByUserId(userId, i);
                postResponse = await responseMessages.Content.ReadFromJsonAsync<PaginatedPostResponse>();

                foreach (ForumPost forumPost in postResponse!.Posts)
                {
                    _ = int.TryParse(forumPost.Points, out int points);

                    Post currentPost = new()
                    {
                        UserId = userId,
                        Content = forumPost.Content,
                        Date = forumPost.Date,
                        Points = points
                    };

                    posts.Add(currentPost);
                }

                lastProcessedPage = i;
            }

            await _postRepository.CreateBulkAsync(posts);
            await _postImportRepository.FinishImportAsync(importId, lastProcessedPage);
        }
    }
}
