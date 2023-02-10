using AutoMapper;
using Fenix.DTO;
using Fenix.DTO.Validations;
using Fenix.Models;
using Fenix.Repositories.Interfaces;
using Fenix.Service.Interface;

namespace Fenix.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public CidadeService(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CidadeDTO>> CreateAsync(CidadeDTO cidadeDTO)
        {
            if (cidadeDTO == null)
            {
                return ResultService.Fail<CidadeDTO>("A Cidade está nula");
            }

            var result = new CidadeDTOValidator().Validate(cidadeDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<CidadeDTO>("Erros de validação", result);
            }

            var data = await _cidadeRepository.CreateAsync(_mapper.Map<Cidade>(cidadeDTO));
            return ResultService.Ok(_mapper.Map<CidadeDTO>(data));
        }
    }
}
