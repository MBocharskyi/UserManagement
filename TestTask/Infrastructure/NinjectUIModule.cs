using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TestTask.Contracts;
using TestTask.Service;

namespace TestTask.Infrastructure
{
    public class NinjectUIModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserService>().To<UserService>();
        }
    }
}