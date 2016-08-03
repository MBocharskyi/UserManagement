using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.UserAggregate;

namespace TestTask.Contracts
{
    public interface IUserService
    {
        void Create(User user);

        void Edit(User user);

        void Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();
    }
}
