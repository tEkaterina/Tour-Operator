using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Models;
using Services.Interfaces;

namespace Services.Concrete
{
    public class CityService: ICityService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<City> _cityRepository;

        public CityService(IUnitOfWork uow, IRepository<City> cityRepository)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));
            if (cityRepository == null)
                throw new ArgumentNullException(nameof(cityRepository));

            _uow = uow;
            _cityRepository = cityRepository;
        }

        public void Add(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            _cityRepository.Create(city);
            _uow.Commit();
        }

        public IEnumerable<City> GetAll()
        {
            return _cityRepository.GetAll().AsEnumerable();
        }

    }
}
