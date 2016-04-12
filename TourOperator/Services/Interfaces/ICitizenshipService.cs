using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface ICitizenshipService
    {
        IEnumerable<Citizenship> GetAll();
    }
}
