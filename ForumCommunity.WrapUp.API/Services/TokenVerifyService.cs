using Microsoft.AspNetCore.WebUtilities;

namespace ForumCommunity.WrapUp.API.Services
{
    public class TokenVerifyService
    {
        private readonly HttpClient _httpClient;

        public TokenVerifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerifyToken(string userId, string token)
        {
            Dictionary<string, string?> parameters = new()
            {
                { "act", "Profile" },
                { "MID", userId }
            };

            string requestUri = QueryHelpers.AddQueryString("?", parameters);

            HttpResponseMessage? response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            string rawResponse = await response.Content.ReadAsStringAsync();
            bool responseContainsToken = rawResponse.Contains(token);

            return responseContainsToken;
        }
    }
}
