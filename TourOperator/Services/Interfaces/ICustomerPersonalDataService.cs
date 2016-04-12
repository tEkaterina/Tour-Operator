using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface ICustomerPersonalDataService
    {
        void Add(CustomerPersonalData customer);
        void Update(CustomerPersonalData customer);
        void Remove(int id);

        IEnumerable<CustomerPersonalData> GetAll();
        CustomerPersonalData GetById(int id);

    }
}
