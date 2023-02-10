using Fenix.Models;

namespace Fenix.Repositories.Interfaces
{
    public interface ICidadeRepository
    {
        Task<Cidade> GetByIdAsync(int id);
        Task<ICollection<Cidade>> GetCidadesAsync();
        Task<Cidade> CreateAsync(Cidade cidade);
    }
}
