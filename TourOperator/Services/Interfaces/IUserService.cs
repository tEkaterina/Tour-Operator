using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(int id);
        void Update(User user);

        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
    }
}
