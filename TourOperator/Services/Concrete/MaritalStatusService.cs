using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class MaritalStatusService: IMaritalStatusService
    {
        private readonly IRepository<MaritalStatus> _maritalRepository;

        public MaritalStatusService(IRepository<MaritalStatus> maritalRepository)
        {
            _maritalRepository = maritalRepository;
        }

        public IEnumerable<MaritalStatus> GetAll()
        {
            return _maritalRepository.GetAll().AsEnumerable();
        } 
    }
}
