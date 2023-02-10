using Fenix.DTO;

namespace Fenix.Service.Interface
{
    public interface IClienteService
    {
        public Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO);
    }
}
