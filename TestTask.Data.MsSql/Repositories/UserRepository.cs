using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Contracts;
using TestTask.Data.MsSql.Entities;
using TestTask.Data.MsSql.Mappers;
using TestTask.Domain.UserAggregate;

namespace TestTask.Data.MsSql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestTaskUnitOfWork _unitOfWork;
        private readonly DbSet<UserEntity> _dalUser;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (TestTaskUnitOfWork)unitOfWork;
            _dalUser = _unitOfWork.Context.Users;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public void Add(User addEntity)
        {
            var userEntity = new UserEntity();
            DomainToDal.Map(userEntity, addEntity);
            _dalUser.Add(userEntity);
            _unitOfWork.Commit();
            addEntity.Id = userEntity.Id;
        }

        public void Remove(int id)
        {
            var userEntity = new UserEntity { Id = id };

            _dalUser.Attach(userEntity);
            _dalUser.Remove(userEntity);
        }

        public void Update(User updateEntity)
        {
            var userEntity = _dalUser.SingleOrDefault(u => u.Id == updateEntity.Id);

            if (userEntity == null)
            {
                throw new ArgumentException("entity");
            }

            DomainToDal.Map(userEntity, updateEntity);
        }
    }
}
