using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetAll();
    }
}
