using ForumCommunity.WrapUp.API.Configurations;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace ForumCommunity.WrapUp.API.Services
{
    public class RandomStringGenerator : ILoginTokenGenerator
    {
        private readonly RandomStringGeneratorConfiguration _configuration;

        public RandomStringGenerator(RandomStringGeneratorConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
            ArgumentNullException.ThrowIfNull(configuration.Charset, nameof(configuration.Charset));

            if (configuration.Length <= 0)
                throw new ArgumentOutOfRangeException(nameof(configuration.Length), "Length must be greater than 0");

            _configuration = configuration;
        }

        public RandomStringGenerator(IOptions<RandomStringGeneratorConfiguration> configuration) : this(configuration.Value)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        }

        public string GenerateToken()
        {
            StringBuilder password = new();

            using (RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[sizeof(uint)];

                for (int i = 0; i < _configuration.Length; i++)
                {
                    randomGenerator.GetBytes(buffer);
                    uint num = BitConverter.ToUInt32(buffer, 0);
                    password.Append(_configuration.Charset![(int)(num % _configuration.Charset.Length)]);
                }
            }
            return password.ToString();
        }
    }
}
