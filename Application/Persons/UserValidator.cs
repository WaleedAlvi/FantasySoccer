using Domain;
using FluentValidation;

namespace Application.Persons
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirebaseID).NotEmpty().Length(28);
            RuleFor(x => x.PersonID).NotEmpty();
        }
    }
}