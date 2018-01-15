﻿using DataBaseInterfaces.Entities;
using System;

namespace DataBaseLibrary.Entities
{
    public class Conversation : IConversation
    {
        public int ConversationId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
