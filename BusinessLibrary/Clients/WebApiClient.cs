using BusinessInterfaces.Clients;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;

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

        public async Task CreateConversation(string message)
        {
            using (httpClient)
            {
                await httpClient.PostAsJsonAsync($"api/Employee", message);
            }
        }

        public async Task<string> GetAllConversationsAsync()
        {
            using (httpClient)
            {
                var result = await httpClient.GetAsync("api/Employee/",
                    HttpCompletionOption.ResponseContentRead);

                return await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetConversation(int id)
        {
            var result = await httpClient.GetAsync($"api/Employee/{id}",
                HttpCompletionOption.ResponseContentRead);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
