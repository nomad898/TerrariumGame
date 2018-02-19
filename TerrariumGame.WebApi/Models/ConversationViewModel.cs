using System;

namespace TerrariumGame.WebApi.Models
{
    public class ConversationViewModel 
    {
        public virtual int ConversationId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Message { get; set; }
    }
}