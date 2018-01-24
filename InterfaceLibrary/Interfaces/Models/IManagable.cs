namespace InterfaceLibrary.Interfaces
{
    public interface IManagable
    {
        int DoneWork { get; set; }
        void DoWork();
        void DoWork(IWork work);
        void TakeSalaryAddition(ISalaryAddition salary);
    }
}
