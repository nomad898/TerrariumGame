﻿using InterfaceLibrary.Interfaces.UI;
using InterfaceLibrary.Interfaces.Writer;

namespace InterfaceLibrary.Interfaces
{
    public interface IMapManipulator
    {
        IMap Map { get; }

        IGameObjectFactory GameObjectFactory { get; }
        
        IMessageWriter MessageWriter { get; }        

        void SetObjects();        
    }
}
