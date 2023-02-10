using Fenix.DTO;

namespace Fenix.Service.Interface
{
    public interface ICidadeService
    {
        public Task<ResultService<CidadeDTO>> CreateAsync(CidadeDTO clienteDTO);
    }
}
