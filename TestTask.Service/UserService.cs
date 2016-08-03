using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts;
using TestTask.Data.Contracts;
using TestTask.Data.Queries.Common;
using TestTask.Domain.UserAggregate;

namespace TestTask.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuery<User, GetByIdCriteria> _getById;
        private readonly IQuery<IEnumerable<User>, GetAllCriteria> _getAll;

        public UserService(IUserRepository userRepository,
            IQuery<User, GetByIdCriteria> getById,
            IQuery<IEnumerable<User>, GetAllCriteria> getAll)
        {
            _userRepository = userRepository;
            _getById = getById;
            _getAll = getAll;
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("user");
            }

            ValidateUser(user);
            _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user == null)
            {
                throw new ArgumentException("user");
            }
            _userRepository.Remove(id);
            _userRepository.UnitOfWork.Commit();
        }

        public void Edit(User user)
        {
            ValidateUser(user);
            try
            {
                _userRepository.Update(user);
            }
            catch (ArgumentException)
            {
                throw;
            }
            _userRepository.UnitOfWork.Commit();
        }

        public User Get(int id)
        {
            return _getById.Execute(new GetByIdCriteria { Id = id });
        }

        public IEnumerable<User> GetAll()
        {
            return _getAll.Execute(new GetAllCriteria());
        }

        private void ValidateUser(User user)
        {
            if (!UserValidation.IsValid(user))
            {
                throw new ArgumentException("User not valid");
            }
        }
    }
}
