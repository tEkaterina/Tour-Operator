using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IMaritalStatusService
    {
        IEnumerable<MaritalStatus> GetAll();
    }
}
