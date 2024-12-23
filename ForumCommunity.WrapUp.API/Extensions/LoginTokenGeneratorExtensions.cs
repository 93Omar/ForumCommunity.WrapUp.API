using ForumCommunity.WrapUp.API.Configurations;
using ForumCommunity.WrapUp.API.Services;

namespace ForumCommunity.WrapUp.API.Extensions
{
    public static class LoginTokenGeneratorExtensions
    {
        public static IServiceCollection AddLoginTokenGenerator(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<RandomStringGeneratorConfiguration>(configuration.GetSection(nameof(RandomStringGeneratorConfiguration)));

            services.AddTransient<ILoginTokenGenerator, RandomStringGenerator>();

            return services;
        }
    }
}
