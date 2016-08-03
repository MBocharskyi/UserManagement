using TestTask.Data.Contracts;

namespace TestTask.Data.Queries.Common
{
    public class GetByIdCriteria : IQueryCriteria
    {
        public int Id { get; set; }
    }
}
