namespace TestTask.Data.Contracts
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
