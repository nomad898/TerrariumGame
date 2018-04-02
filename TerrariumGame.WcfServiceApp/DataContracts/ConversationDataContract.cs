using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TerrariumGame.WcfServiceApp.DataContracts
{
    [DataContract]
    public class ConversationDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}