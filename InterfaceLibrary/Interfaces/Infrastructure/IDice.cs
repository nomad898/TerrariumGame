namespace InterfaceLibrary.Interfaces
{
    public interface IDice
    {       
        int Chance { get; set; }
        int Limit { get; set; }

        void ChangeObjectPosition(IMovable mvbl, IMap map);
    }
}
