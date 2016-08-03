namespace TestTask.Data.Contracts
{
    public interface IQuery<out TResult, in TCriteria> where TCriteria : IQueryCriteria
    {
        TResult Execute(TCriteria criteria);
    }
}
