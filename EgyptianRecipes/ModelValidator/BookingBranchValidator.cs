using EgyptianRecipes.Models.Request;
using FluentValidation;

namespace EgyptianRecipes.ModelValidator
{
    public class BookingBranchValidator : AbstractValidator<BookingBranch>
    {
        public BookingBranchValidator()
        {
            RuleFor(c=> c.clientName).NotEmpty();
            RuleFor(c=> c.clientPhone).NotEmpty();
            RuleFor(c => c.clientEmail).EmailAddress();
        }
    }
}
