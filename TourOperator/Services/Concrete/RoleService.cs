using System;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;

        public RoleService(IRepository<Role> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        public Role GetByName(string name)
        {
            return _repository.GetByPredicate(role => role.Name == name);
        }
    }
}
