using Models;

namespace Services.Interfaces
{
    public interface ICustomerContactDataService
    {
        void Update(CustomerContactData customerContactData);
        CustomerContactData GetById(int id);
    }
}
