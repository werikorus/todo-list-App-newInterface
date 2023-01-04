using FluentValidation;
using TodoList.Services.Models;

namespace TodoList.Services.Validators;

public class TaskListModelValidator : AbstractValidator<TaskListModel>
{
    public TaskListModelValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("List object not informed!");
        
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Invalid Identifier!");

        RuleFor(x => x.IdList)
            .NotNull().WithMessage("IdList must not be NULL!")
            .NotEmpty().WithMessage("IdList must not be EMPTY!");

        RuleFor(x => x.DescriptionTask)
            .NotNull().WithMessage("DescriptionTask must not be NULL!")
            .NotEmpty().WithMessage("DescriptionTask must not be EMPTY!");

        RuleFor(x => x.Done)
            .NotNull().WithMessage("Done must not be NULL!")
            .NotEmpty().WithMessage("Done mut not be EMPTY!");
        
        RuleFor(x => x.DateCreate)
            .NotNull().WithMessage("DateCreate must not be NULL!")
            .NotEmpty().WithMessage("DateCreate must not be EMPTY!");
        
        RuleFor(x => x.DateUpdate)
            .NotNull().WithMessage("DateUpdate must not be NULL!")
            .NotEmpty().WithMessage("DateUpdate must not be EMPTY!");
    }
}