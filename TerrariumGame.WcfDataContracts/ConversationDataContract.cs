using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.WcfDataContracts
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
