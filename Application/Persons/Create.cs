using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PersonUserDto Person { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Person).SetValidator(new PersonUserValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var newPerson = new Person
                {
                    FirstName = request.Person.FirstName,
                    LastName = request.Person.LastName,
                    DateOfBirth = request.Person.DateOfBirth,
                    CountryID = request.Person.CountryID,
                    TeamID = request.Person.TeamID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                _context.Persons.Add(newPerson);

                _context.Users.Add(new User
                {
                    FirebaseID = request.Person.FireBaseID,
                    PersonID = newPerson.PersonID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                });
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create account");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}