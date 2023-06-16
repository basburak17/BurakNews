using BurakNews.Core.DTOs;
using FluentValidation;

namespace BurakNews.Service.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
        }
    }
}
