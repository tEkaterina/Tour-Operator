using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IDisabilityService
    {
        IEnumerable<Disability> GetAll();
    }
}
