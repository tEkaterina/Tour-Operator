using System;
using System.Collections.Generic;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<User> _repository; 

        public UserService(IUnitOfWork uow, IRepository<User> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public void Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _repository.Create(user);
            _uow.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
