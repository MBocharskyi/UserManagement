using TestTask.Data.Contracts;
using TestTask.Data.MsSql.Context;

namespace TestTask.Data.MsSql
{
    public class TestTaskUnitOfWork : IUnitOfWork
    {
        private readonly TestTaskEntities _context;

        public TestTaskUnitOfWork()
        {
            _context = new TestTaskEntities();
        }

        public TestTaskEntities Context
        {
            get
            {
                return _context;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
