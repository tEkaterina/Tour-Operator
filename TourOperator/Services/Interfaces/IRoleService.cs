using Models;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        Role GetByName(string name);
    }
}
