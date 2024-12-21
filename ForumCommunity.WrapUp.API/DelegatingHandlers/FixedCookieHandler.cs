namespace ForumCommunity.WrapUp.API.DelegatingHandlers
{
    internal class FixedCookieHandler : DelegatingHandler
    {
        private readonly string? _cookie;

        public FixedCookieHandler(string? cookie)
        {
            _cookie = cookie;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("Cookie") && !string.IsNullOrEmpty(_cookie))
                request.Headers.Add("Cookie", _cookie);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}