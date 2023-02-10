using Fenix.Models;

namespace Fenix.Repositories.Interfaces
{
    public interface ICidadeRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<ICollection<Cliente>> GetClientesAsync();
        Task<Cliente> CreateAsync(Cliente cliente);
    }
}
