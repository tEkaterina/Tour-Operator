using System;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class CustomerContactDataService : ICustomerContactDataService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CustomerContactData> _contactDataRepository;

        public CustomerContactDataService(IUnitOfWork uow, IRepository<CustomerContactData> contactDataRepository)
        {
            if(uow == null)
                throw new ArgumentNullException(nameof(uow));
            if(contactDataRepository == null)
                throw new ArgumentNullException(nameof(contactDataRepository));

            _uow = uow;
            _contactDataRepository = contactDataRepository;
        }

        public void Update(CustomerContactData customerContactData)
        {
            if (customerContactData == null)
                throw new ArgumentNullException(nameof(customerContactData));
            _contactDataRepository.Update(customerContactData);
            _uow.Commit();
        }

        public CustomerContactData GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Invalid specified id = {id}. Id must be greater than zero.");
            return _contactDataRepository.GetById(id);
        }
    }
}
