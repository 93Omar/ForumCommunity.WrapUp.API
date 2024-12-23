using ForumCommunity.WrapUp.API.Configurations;
using ForumCommunity.WrapUp.API.DelegatingHandlers;
using ForumCommunity.WrapUp.API.Services;
using ForumFree.NET;
using Microsoft.Extensions.Options;

namespace ForumCommunity.WrapUp.API.Extensions
{
    public static class ClientExtensions
    {
        public static IServiceCollection AddForumClients(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<ForumConfiguration>(configuration.GetSection(nameof(ForumConfiguration)));

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
