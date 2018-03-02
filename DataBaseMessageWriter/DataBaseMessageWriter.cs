using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using BusinessInterfaces.Services;
using TerrariumGame.Dto.DTO;
using System;
using BusinessInterfaces.Clients;

namespace MessageWriter
{
    class DataBaseMessageWriter : IMessageWriter
    {
        private readonly IWebApiClient webApiClient;

        public DataBaseMessageWriter(IWebApiClient webApiClient)
        {
            this.webApiClient = webApiClient;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            
        }
        #endregion
    }
}
