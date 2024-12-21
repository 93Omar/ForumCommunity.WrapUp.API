using ForumCommunity.WrapUp.API.Configurations;
using ForumCommunity.WrapUp.API.Services;
using ForumFree.NET;
using Microsoft.Extensions.Options;
using NillForum.WrapUp.API.DelegatingHandlers;

namespace ForumCommunity.WrapUp.API.Extensions
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddForumClients(this IServiceCollection services)
        {
            services.AddHttpClient<ForumFreeClient>((sp, client) =>
            {
                ForumConfiguration forumConfiguration = sp.GetRequiredService<IOptions<ForumConfiguration>>()?.Value ?? throw new ArgumentNullException(nameof(ForumConfiguration));
                client.BaseAddress = forumConfiguration.ForumUri;
            })
            .AddHttpMessageHandler((sp) =>
            {
                ForumConfiguration forumConfiguration = sp.GetRequiredService<IOptions<ForumConfiguration>>()?.Value ?? throw new ArgumentNullException(nameof(ForumConfiguration));
                return new FixedCookieHandler(forumConfiguration.Cookie);
            });

            services.AddHttpClient<TokenVerifyService>((sp, client) =>
            {
                ForumConfiguration forumConfiguration = sp.GetRequiredService<IOptions<ForumConfiguration>>()?.Value ?? throw new ArgumentNullException(nameof(ForumConfiguration));
                client.BaseAddress = forumConfiguration.ForumUri;
            });

            return services;
        }
    }
}
