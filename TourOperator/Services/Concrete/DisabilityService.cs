using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class DisabilityService: IDisabilityService
    {
        private readonly IRepository<Disability> _disabilityRepository;

        public DisabilityService(IRepository<Disability> disabilityRepository)
        {
            _disabilityRepository = disabilityRepository;
        }

        public IEnumerable<Disability> GetAll()
        {
            return _disabilityRepository.GetAll().AsEnumerable();
        } 
    }
}
