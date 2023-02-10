using Fenix.Models;
using Fenix.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fenix.Repositories
{
    public class ClienteRepository : ICidadeRepository
    {
        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _dataContext.Add(cliente);
            await _dataContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _dataContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Cliente>> GetClientesAsync()
        {
            return await _dataContext.Clientes.ToListAsync();
        }
    }
}
