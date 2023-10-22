using EntityFrameworkMvc.Dtos;
using FluentValidation;

namespace EntityFrameworkMvc.Validator
{
    public class SaveBookDtoValidator : AbstractValidator<SaveBookDto>
    {
        public SaveBookDtoValidator() 
        { 
            RuleFor(x => x.Title)
                            .NotEmpty()
                            .NotNull()
                            .MaximumLength(80)
                            .MinimumLength(10);
            RuleFor(x => x.ISBN)
                            .NotEmpty()
                            .NotNull()
                            .MaximumLength(30)
                            .MinimumLength(5);
            RuleFor(x => x.Autor)
                            .NotEmpty()
                            .NotNull()
                            .MaximumLength(100)
                            .MinimumLength(10);
            RuleFor(x => x.Year)
                            .NotEmpty()
                            .NotNull();
            RuleFor(x => x.Price)
                            .NotEmpty()
                            .NotNull();
            RuleFor(x => x.Commentary)
                            .MaximumLength(150);
            RuleFor(x => x.EditorialId)
                            .NotEmpty()
                            .NotNull();
        }
    }
}
