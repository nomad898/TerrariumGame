using BusinessInterfaces.Clients;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BusinessLibrary.Clients
{
    public class WebApiClient : IWebApiClient
    {
        private HttpClient httpClient;

        public WebApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50808/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public WebApiClient(HttpClient httpClient, Uri uri)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = uri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task CreateConversationAsync(string message)
        {
            using (httpClient)
            {
                StringContent queryString = new StringContent(message);
                await httpClient.PostAsync($"api/Conversation/{message}", queryString);
            }
        }

        public async Task<string> GetAllConversationsAsync()
        {
            using (httpClient)
            {
                var result = await httpClient.GetAsync("api/Conversation/",
                    HttpCompletionOption.ResponseContentRead);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetConversationAsync(int id)
        {
            var result = await httpClient.GetAsync($"api/Conversation/{id}",
                HttpCompletionOption.ResponseContentRead);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
