using DataBaseInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerrariumGame.WebApi.Models
{
    public class ConversationViewModel : IConversation
    {
        public virtual int ConversationId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Message { get; set; }

        public void TransferData(IConversation entity)
        {
            Date = entity.Date;
            Message = entity.Message;
        }
    }
}