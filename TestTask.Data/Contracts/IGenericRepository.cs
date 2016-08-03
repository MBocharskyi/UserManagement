namespace TestTask.Data.Contracts
{
    public interface IGenericRepository<T> : IRepository where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(int id);
    }
}
