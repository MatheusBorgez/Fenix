using FluentValidation;

namespace Fenix.DTO.Validations
{
    public class ClienteDTOValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteDTOValidator() 
        {
            RuleFor(c => c.Telefone).NotNull().NotEmpty().WithMessage("O telefone é obrigatório");
            RuleFor(c => c.Bairro).NotNull().NotEmpty().WithMessage("O bairro é obrigatório");
            RuleFor(c => c.Endereco).NotNull().NotEmpty().WithMessage("O endereço é obrigatório");
            RuleFor(c => c.Cep).NotNull().NotEmpty().WithMessage("O CEP é obrigatório");
            RuleFor(c => c.Cidade).NotNull().NotEmpty().WithMessage("A cidade é obrigatória");
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("O nome é obrigatório");
        }
    }
}
