using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Thomerson.Gatlin.Core;

namespace Thomerson.Gatlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdRequestController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public ThirdRequestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("xxx");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ThirdRequest2Controller : ControllerBase
    {

        private readonly GitHubClient _GitHubClient;
        public ThirdRequest2Controller(GitHubClient gitHubClient)
        {
            _GitHubClient = gitHubClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            string result = await _GitHubClient.GetData();
            return Ok(result);
        }
    }
}
