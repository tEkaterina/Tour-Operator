using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface ICityService
    {
        void Add(City city);
        IEnumerable<City> GetAll();
    }
}
