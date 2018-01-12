namespace InterfaceLibrary.Interfaces
{
    public interface IFactory<T> where T: class
    {
        T Create(int id);
    }
}
