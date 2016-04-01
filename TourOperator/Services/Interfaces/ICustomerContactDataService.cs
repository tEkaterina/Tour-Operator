using Models;

namespace Services.Interfaces
{
    public interface ICustomerContactDataService
    {
        void Add(CustomerContactData customerContactData);
        CustomerContactData GetById(int id);
    }
}
