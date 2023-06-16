using BurakNews.Core.DTOs;
using FluentValidation;

namespace BurakNews.Service.Validations
{
    public class NewDtoValidator : AbstractValidator<NewDto>
    {
        public NewDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Author).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
