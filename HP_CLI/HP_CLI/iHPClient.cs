using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HP_CLI
{
    public class iHPClient
    {
        private readonly HttpClient _httpClient;
        private readonly UserProfile _userProfile;
        private readonly ILogger _logger;

        public iHPClient(HttpClient httpClient, UserProfile userProfile, ILogger logger)
        {
            _httpClient = httpClient;
            _userProfile = userProfile;
            _logger = logger;
        }

        public async Task<string> GetAsync(string url)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            return await Request(requestMessage);
        }

        private async Task<string> Request(HttpRequestMessage requestMessage)
        {
            //_httpClient.BaseAddress = new Uri(_host);
            return null;
        }
    }
}
