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

        public void Remove(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Invalid id = {id}: id must be greater than zero.");
            _repository.Delete(_repository.GetById(id));
            _uow.Commit();
        }

        public void Update(User user)
        {
            _repository.Update(user);
            _uow.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Invalid id = {id}: id must be greater than zero.");
            return _repository.GetById(id);
        }

        public User GetByEmail(string email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));
            return _repository.GetByPredicate(u => u.Email == email);
        }
    }
}
