using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid PersonID { get; set; }
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
                var person = await _context.Persons.FindAsync(request.PersonID);
                if (person == null) return null;
                _context.Remove(person);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete account");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}