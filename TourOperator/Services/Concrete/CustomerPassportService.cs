using System;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class CustomerPassportService : ICustomerPassportService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CustomerPassport> _passportRepository;

        public CustomerPassportService(IUnitOfWork uow, IRepository<CustomerPassport> passportRepository)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));
            if(passportRepository == null)
                throw new ArgumentNullException(nameof(passportRepository));

            _uow = uow;
            _passportRepository = passportRepository;
        }

        public void Add(CustomerPassport passport)
        {
            throw new NotImplementedException();
        }

        public CustomerPassport GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
