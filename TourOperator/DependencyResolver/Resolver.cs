using System.Data.Entity;
using DataAccess.Concrete;
using DataAccess.Interfaces;
using Models;
using Ninject;
using Ninject.Web.Common;
using Orm;
using Services.Concrete;
using Services.Interfaces;

namespace DependencyResolver
{
    public static class Resolver
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IRepository<User>>().To<Repository<User>>();
            kernel.Bind<IRepository<Role>>().To<Repository<Role>>();
            kernel.Bind<IRepository<CustomerPersonalData>>()
                .To<Repository<CustomerPersonalData>>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ICustomerPersonalDataService>()
                .To<CustomerPersonalDataService>();
        }
    }
}
