using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TestTask.Data.MsSql.Repositories;
using TestTask.Domain.UserAggregate;

namespace TestTask.Service.Infrastructure
{
    public class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
