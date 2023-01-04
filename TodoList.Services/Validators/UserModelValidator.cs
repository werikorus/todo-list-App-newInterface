using System.Data;
using FluentValidation;
using TodoList.Services.Models;

namespace TodoList.Services.Validators;

public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("User object not informed!");

        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Invalid Identifier!");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name for User must not be NULL!")
            .NotEmpty().WithMessage("Name for User must not be EMPTY!");

        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email for User must not be NULL!")
            .NotEmpty().WithMessage("Email for User must not be EMPTY!");

        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password for User must not be NULL!")
            .NotEmpty().WithMessage("Password for User must not be EMPTY!");

        RuleFor(x => x.DateCreate)
            .NotNull().WithMessage("DateCreate for User must not be NULL!")
            .NotEmpty().WithMessage("DateCreate for User must not be EMPTY!");
        
        RuleFor(x => x.DateUpdate)
            .NotNull().WithMessage("DateUpdate for User must not be NULL!")
            .NotEmpty().WithMessage("DateUpdate for User must not be EMPTY!");
    }
    
}