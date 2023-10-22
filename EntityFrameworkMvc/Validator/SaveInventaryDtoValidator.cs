using EntityFrameworkMvc.Dtos;
using FluentValidation;

namespace EntityFrameworkMvc.Validator
{
    public class SaveInventaryDtoValidator : AbstractValidator<SaveInventaryDto>
    {
        public SaveInventaryDtoValidator()
        {
            RuleFor(x => x.Stock)
                            .NotNull()
                            .NotEmpty();
            RuleFor(x => x.BranchId)
                            .NotEmpty()
                            .NotNull();
            RuleFor(x => x.BookId)
                            .NotEmpty()
                            .NotNull();
        }
    }
}
