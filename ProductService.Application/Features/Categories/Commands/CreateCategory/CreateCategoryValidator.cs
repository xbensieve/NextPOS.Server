using FluentValidation;

namespace ProductService.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .MaximumLength(200);
        }
    }
}
