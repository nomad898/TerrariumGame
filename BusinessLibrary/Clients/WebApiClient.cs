using BusinessInterfaces.Clients;
using System.Net.Http;
using TerrariumGame.Dto.DTO;

namespace BusinessLibrary.Clients
{
    public class WebApiClient : IWebApiClient
    {
        public void CreateConversation()
        {
            using (var client = new HttpClient())
            {
            //    client.Headers.Add("Content-Type:application/json");
            //    client.Headers.Add("Accept:application/json");
            //    var result = client.DownloadString("http://localhost:50808/api/Conversation");
            }
        }

        public string GetAllConversations()
        {
            using (var client = new HttpClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:50808/api/Conversation");
                return result;      
            }
        }

        private ConversationDto GetConversation(string path)
        {
            ConversationDto conversationDto = null;
            HttpResponseMessage response = await clie
        }
    }
}
