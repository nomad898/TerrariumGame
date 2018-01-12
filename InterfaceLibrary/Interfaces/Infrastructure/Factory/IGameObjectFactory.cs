namespace InterfaceLibrary.Interfaces
{
    public interface IGameObjectFactory : IFactory<IGameObject>
    {
        IGameObject Create(int id, int x, int y);
        IGameObject Create(int id, string name, int x, int y);
        IGameObject Create(int id, string name, decimal salary, int x, int y);
    }
}
