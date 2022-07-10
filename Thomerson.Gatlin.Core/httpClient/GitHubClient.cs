using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Thomerson.Gatlin.Core
{
    //public class GitHubClient
    //{
    //    public HttpClient Client { get; private set; }

    //    public GitHubClient(HttpClient httpClient)
    //    {
    //        httpClient.BaseAddress = new Uri("https://api.github.com/");
    //        httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
    //        httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
    //        Client = httpClient;
    //    }
    //}

    public interface IGitHubClient
    {
        Task<string> GetData();
    }

    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _client;

        public GitHubClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.github.com/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;
        }

        public async Task<string> GetData()
        {
            return await _client.GetStringAsync("/");
        }
    }

}
