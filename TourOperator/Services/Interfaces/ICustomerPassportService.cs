using Models;

namespace Services.Interfaces
{
    public interface ICustomerPassportService
    {
        void Update(CustomerPassport passport);
        CustomerPassport GetById(int id);
    }
}
