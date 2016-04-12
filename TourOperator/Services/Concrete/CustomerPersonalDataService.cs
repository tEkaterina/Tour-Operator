using System;
using System.Collections.Generic;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class CustomerPersonalDataService : ICustomerPersonalDataService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CustomerPersonalData> _customerRepository; 

        public CustomerPersonalDataService(IUnitOfWork uow, 
            IRepository<CustomerPersonalData> customeRepository)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));
            if (customeRepository == null)
                throw new ArgumentNullException(nameof(customeRepository));

            _uow = uow;
            _customerRepository = customeRepository;
        }

        public void Add(CustomerPersonalData customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Create(customer);
            _uow.Commit();
        }

        public void Update(CustomerPersonalData customer)
        {
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Update(customer);
            _uow.Commit();
        }

        public void Remove(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Invalid id = {id}: id must be greater than zero.");
            _customerRepository.Delete(GetById(id));
            _uow.Commit();
        }

        public IEnumerable<CustomerPersonalData> GetAll()
        {
            return _customerRepository.GetAll();
        }
        
        public CustomerPersonalData GetById(int id)
        {
            return _customerRepository.GetById(id);
        }
    }
}
