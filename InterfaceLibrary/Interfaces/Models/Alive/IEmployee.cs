namespace InterfaceLibrary.Interfaces
{
    public interface IEmployee : IGameObject
    {
        decimal Salary { get; set; }
        string Name { get; set; }
        bool Mood { get; set; }
        string Talk(IEmployee ee);
    }
}
