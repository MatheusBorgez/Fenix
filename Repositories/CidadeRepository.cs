using Fenix.Models;
using Fenix.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fenix.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly DataContext _dataContext;
        public CidadeRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<Cidade> CreateAsync(Cidade cidade)
        {
            _dataContext.Add(cidade);
            await _dataContext.SaveChangesAsync();
            return cidade;
        }

        public async Task<Cidade> GetByIdAsync(int id)
        {
            return await _dataContext.Cidades.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Cidade>> GetCidadesAsync()
        {
            return await _dataContext.Cidades.ToListAsync();
        }
    }
}
