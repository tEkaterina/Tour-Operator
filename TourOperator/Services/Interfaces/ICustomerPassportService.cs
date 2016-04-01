using Models;

namespace Services.Interfaces
{
    public interface ICustomerPassportService
    {
        void Add(CustomerPassport passport);
        CustomerPassport GetById(int id);
    }
}
