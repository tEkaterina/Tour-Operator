using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class CitizenshipService: ICitizenshipService
    {
        private readonly IRepository<Citizenship> _citizenshipRepository;

        public CitizenshipService(IRepository<Citizenship> citizenshipRepository)
        {
            _citizenshipRepository = citizenshipRepository;
        }

        public IEnumerable<Citizenship> GetAll()
        {
            return _citizenshipRepository
                .GetAll()
                .AsEnumerable();
        } 
    }
}
