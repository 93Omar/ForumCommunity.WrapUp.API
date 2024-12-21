using ForumFree.NET;
using Microsoft.Extensions.Options;
using NillForum.WrapUp.API.Configurations;
using NillForum.WrapUp.API.DelegatingHandlers;

namespace NillForum.WrapUp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddUserSecrets<Program>();

            IServiceCollection services = builder.Services;

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<ForumConfiguration>(builder.Configuration.GetSection(nameof(ForumConfiguration)));

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

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
