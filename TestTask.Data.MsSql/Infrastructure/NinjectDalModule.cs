using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using TestTask.Data.Contracts;
using TestTask.Data.MsSql.Queries;

namespace TestTask.Data.MsSql.Infrastructure
{
    public class NinjectDalModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind(x => x.FromThisAssembly()
                .SelectAllClasses()
                .InNamespaceOf<UserQueries>()
                .BindAllInterfaces()
                .Configure(c => c.InTransientScope()));

            Kernel.Bind<IUnitOfWork>().To<TestTaskUnitOfWork>();
        }
    }
}
