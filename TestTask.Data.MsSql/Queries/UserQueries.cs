using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Contracts;
using TestTask.Data.MsSql.Entities;
using TestTask.Data.MsSql.Mappers;
using TestTask.Data.Queries.Common;
using TestTask.Domain.UserAggregate;

namespace TestTask.Data.MsSql.Queries
{
    public class UserQueries : IQuery<User, GetByIdCriteria>,
        IQuery<IEnumerable<User>, GetAllCriteria>
    {
        private readonly TestTaskUnitOfWork _unitOfWork;
        private readonly DbSet<UserEntity> _dalUser;

        public UserQueries(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (TestTaskUnitOfWork)unitOfWork;
            _dalUser = _unitOfWork.Context.Users;
        }

        public IEnumerable<User> Execute(GetAllCriteria criteria)
        {
            return _dalUser.Select(DalToDomain.Map).ToList();
        }

        public User Execute(GetByIdCriteria criteria)
        {
            return _dalUser
                .Where(u => u.Id == criteria.Id)
                .Select(DalToDomain.Map)
                .SingleOrDefault();
        }
    }
}
