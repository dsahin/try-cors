using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace backend_client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackendClientController : ControllerBase
    {
        private readonly ILogger<BackendClientController> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public BackendClientController(ILogger<BackendClientController> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<Response> Get()
        {
            var response = new Response
            {
            };

            HttpClient httpClient = httpClientFactory.CreateClient();
            response.HttpResponseMessage = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://nginx-proxy/")
            {
                Headers = {
                    { HeaderNames.UserAgent, "BackendClient" },
                    { HeaderNames.Host, "corsb.local" },
                }
            });

            if (response.HttpResponseMessage.IsSuccessStatusCode)
            {
                response.Body = await response.HttpResponseMessage.Content.ReadAsStringAsync();
            }

            return response;
        }
    }

    public class Response
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public string Body { get; set; }
    }
}