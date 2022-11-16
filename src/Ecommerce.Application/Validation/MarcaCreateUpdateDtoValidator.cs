
using Ecommerce.Application.Dtos;
using FluentValidation;

namespace Ecommerce.Application.Validation;

public class MarcaCreateUpdateDtoValidator : AbstractValidator<MarcaCreateUpdateDto>
{
    public MarcaCreateUpdateDtoValidator()
    {
        //RuleFor(x => x).Must(x => false).WithMessage("Verificacion de validaciones del Proyecto");

        //RuleFor(x => x.Nombre).MaximumLength(80);
    }
}
