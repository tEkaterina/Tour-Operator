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

        public void Update(CustomerPassport passport)
        {
            if (passport == null)
                throw new ArgumentNullException(nameof(passport));

            _passportRepository.Update(passport);
            _uow.Commit();
        }

        public CustomerPassport GetById(int id)
        {
            return _passportRepository.GetById(id);
        }
    }
}
