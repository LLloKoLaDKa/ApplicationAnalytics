using AA.Domain.Applications.Events;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AA.UI.Tools
{
    internal class HttpHelper
    {
        private static readonly HttpClient _client = new();
        public static readonly String _host = "https://localhost:44356/";

        public static async Task SaveEvent(ApplicationEventBlank applicationEvent)
        {
            String fullUrl = _host + "Events/Save";

            HttpRequestMessage request = new(HttpMethod.Post, fullUrl);
            request.Content = JsonContent.Create(applicationEvent);
            HttpResponseMessage responseMessage = await _client.SendAsync(request);
            String response = await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
