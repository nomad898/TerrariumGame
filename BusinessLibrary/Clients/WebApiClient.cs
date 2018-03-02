﻿using BusinessInterfaces.Clients;
using System;
using System.Net;

namespace BusinessLibrary.Clients
{
    public class WebApiClient : IWebApiClient
    {
        public string GetAllConversations()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:50808/api/Conversation");
                return result;      
            }
        }
    }
}
