using FluentValidation;
using inventario.Application.Features.Inventarios.DTOs;
namespace inventario.Application.Features.Inventarios.Validators;

public class CreateInventarioValidator : AbstractValidator<CreateInventarioRequestDto>
{
    public CreateInventarioValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del inventario no puede estar vacío.")
            .MinimumLength(3).WithMessage("El inventario debe tener al menos 3 caracteres.")
            .MaximumLength(100).WithMessage("El inventario es demasiado largo.");
    }
}