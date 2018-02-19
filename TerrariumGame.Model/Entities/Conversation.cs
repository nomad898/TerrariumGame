using System;

namespace TerrariumGame.Model.Entities
{
    public class Conversation 
    {
        public virtual int ConversationId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Message { get; set; }    
    }
}
