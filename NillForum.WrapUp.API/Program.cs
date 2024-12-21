using ForumFree.NET;
using Microsoft.Extensions.Options;
using NillForum.WrapUp.API.Configurations;
using NillForum.WrapUp.API.DelegatingHandlers;
using NillForum.WrapUp.API.Extensions;

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

            services.AddForumClients();

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
