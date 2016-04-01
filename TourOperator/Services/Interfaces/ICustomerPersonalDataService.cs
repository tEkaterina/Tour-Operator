using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface ICustomerPersonalDataService
    {
        void Add(CustomerPersonalData customer);
        IEnumerable<CustomerPersonalData> GetAll();
    }
}
