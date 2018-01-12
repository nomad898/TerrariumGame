using InterfaceLibrary.UtilityModels;

namespace InterfaceLibrary.Interfaces
{
    public interface IGameObject : IMovable, IAlivable
    {
        State State { get; set; }
    }
}
