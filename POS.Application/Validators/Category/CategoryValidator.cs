using FluentValidation;
using POS.Application.Dtos.Request;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre de la categoría es requerido.")
                .NotEmpty().WithMessage("El nombre de la categoría no puede estar vacío.")
                .MaximumLength(100).WithMessage("El nombre de la categoría no puede exceder los 100 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción de la categoría no puede exceder los 500 caracteres.");
            RuleFor(x => x.State)
                .InclusiveBetween(0, 1).WithMessage("El estado de la categoría debe ser 0 (inactivo) o 1 (activo).");
        }
    }
}
