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
            kernel.Bind<IRepository<CustomerPersonalData>>().To<Repository<CustomerPersonalData>>();
            kernel.Bind<IRepository<CustomerContactData>>().To<Repository<CustomerContactData>>();
            kernel.Bind<IRepository<CustomerPassport>>().To<Repository<CustomerPassport>>();
            kernel.Bind<IRepository<City>>().To<Repository<City>>();
            kernel.Bind<IRepository<Citizenship>>().To<Repository<Citizenship>>();
            kernel.Bind<IRepository<Disability>>().To<Repository<Disability>>();
            kernel.Bind<IRepository<MaritalStatus>>().To<Repository<MaritalStatus>>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ICustomerPersonalDataService>().To<CustomerPersonalDataService>();
            kernel.Bind<ICustomerContactDataService>().To<CustomerContactDataService>();
            kernel.Bind<ICustomerPassportService>().To<CustomerPassportService>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<ICitizenshipService>().To<CitizenshipService>();
            kernel.Bind<IDisabilityService>().To<DisabilityService>();
            kernel.Bind<IMaritalStatusService>().To<MaritalStatusService>();
        }
    }
}
