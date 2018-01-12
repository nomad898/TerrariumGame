namespace InterfaceLibrary.Interfaces
{
    public interface ICustomer : IGameObject, IManage
    {
        IWork CreateWork();
    }
}
