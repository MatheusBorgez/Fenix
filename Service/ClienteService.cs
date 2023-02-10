using AutoMapper;
using Fenix.DTO;
using Fenix.DTO.Validations;
using Fenix.Models;
using Fenix.Repositories.Interfaces;
using Fenix.Service.Interface;

namespace Fenix.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ICidadeRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(ICidadeRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return ResultService.Fail<ClienteDTO>("O Cliente está nulo");
            }

            var result = new ClienteDTOValidator().Validate(clienteDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<ClienteDTO>("Erros de validação", result);
            }

            var data = await _clienteRepository.CreateAsync(_mapper.Map<Cliente>(clienteDTO));
            return ResultService.Ok(_mapper.Map<ClienteDTO>(data));
        }
    }
}
