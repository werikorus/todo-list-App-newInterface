using FluentValidation;
using TodoList.Services.Models;

namespace TodoList.Services.Validators;

public class ListModelValidator : AbstractValidator<ListModel>
{
    public ListModelValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("List object not informed!");
        
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Invalid Identifier!");

        RuleFor(x => x.DescriptionList)
            .NotNull().WithMessage("DescriptionList must not be NULL!")
            .NotEmpty().WithMessage("DescriptionList must not be EMPTY!");
        
        RuleFor(x => x.DateCreate)
            .NotNull().WithMessage("DateCreate must not be NULL!")
            .NotEmpty().WithMessage("DateCreate must not be EMPTY!");
        
        RuleFor(x => x.DateUpdate)
            .NotNull().WithMessage("DateUpdate must not be NULL!")
            .NotEmpty().WithMessage("DateUpdate must not be EMPTY!");
    }
}