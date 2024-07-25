using EgyptianRecipes.Models.Request;
using FluentValidation;

namespace EgyptianRecipes.ModelValidator
{
    public class BookingBranchValidator : AbstractValidator<BookingBranch>
    {
        public BookingBranchValidator()
        {
            RuleFor(c=> c.clientName).NotEmpty().WithMessage("Name is required!");
            RuleFor(c=> c.clientPhone).NotEmpty().WithMessage("Phone is required!");
            RuleFor(c => c.clientEmail).NotEmpty().WithMessage("Email is required!");
            RuleFor(c => c.clientEmail).EmailAddress().WithMessage("'{PropertyValue}' is not a valid email address!");
        }
    }
}
