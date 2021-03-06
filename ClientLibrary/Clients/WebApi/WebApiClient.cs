﻿using ClientInterfaces.Clients;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TerrariumGame.Model.Entities;

namespace ClientLibrary.Clients
{
    public class WebApiClient : IClient
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
                StringContent queryString = new StringContent(message);
                await httpClient.PostAsync($"api/Conversation/{message}", queryString);                                
        }

        public void CreateConversation(string message)
        {
                StringContent queryString = new StringContent(message);
                httpClient.PostAsync($"api/Conversation/{message}", queryString);         
        }

        public async Task<string> GetAllConversationsAsync()
        {
                var result = await httpClient.GetAsync("api/Conversation/",
                    HttpCompletionOption.ResponseContentRead);
                return await result.Content.ReadAsStringAsync();            
        }

        public async Task<string> GetConversationStringAsync(int id)
        {
            var result = await httpClient.GetAsync($"api/Conversation/{id}",
                HttpCompletionOption.ResponseContentRead);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task UpdateAsync(Conversation entity)
        {
                StringContent queryString = new StringContent(entity.Message);
                await httpClient.PutAsync($"api/Conversation/{entity.ConversationId}/{entity.Message}",
                    queryString);            
        }

        public async Task<Conversation> GetConversationAsync(int id)
        {
            string resultStr = await GetConversationStringAsync(id);
            JObject jObject = JObject.Parse(resultStr);
            string strId = (string)jObject.SelectToken("ConversationId");
            string strDate = (string)jObject.SelectToken("DateTime");
            string strMessage = (string)jObject.SelectToken("Message");
            // TODO datetime parse
            Conversation conversation = new Conversation()
            {
                ConversationId = Int32.Parse(strId),
                Message = strMessage
            };
            return conversation;
        }
    }
}
