using Domain;
using FluentValidation;

namespace Application.Persons
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.CountryID).NotEmpty();
            RuleFor(x => x.TeamID).NotEmpty();
            // RuleFor(x => x.DateCreated).();
            // RuleFor(x => x.DateUpdated).eq();
        }
    }

    public class PersonUserValidator : AbstractValidator<PersonUserDto>
    {
        public PersonUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.CountryID).NotEmpty();
            RuleFor(x => x.TeamID).NotEmpty();
            RuleFor(x => x.FireBaseID).NotEmpty().Length(28);
            // RuleFor(x => x.DateCreated).();
            // RuleFor(x => x.DateUpdated).eq();
        }
    }
}