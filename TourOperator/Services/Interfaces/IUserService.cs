using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        IEnumerable<User> GetAll();
    }
}
