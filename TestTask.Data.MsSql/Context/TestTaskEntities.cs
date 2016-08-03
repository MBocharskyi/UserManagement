using System.Data.Entity;
using TestTask.Data.MsSql.Entities;

namespace TestTask.Data.MsSql.Context
{
    public class TestTaskEntities : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
