using FluentValidation;

namespace Fenix.DTO.Validations
{
    public class CidadeDTOValidator : AbstractValidator<CidadeDTO>
    {
        public CidadeDTOValidator() 
        {
            RuleFor(c => c.UF).NotNull().NotEmpty().WithMessage("O estado não pode ser vazio");
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("O nome não pode ser vazio");
        }
    }
}
