using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid PersonID { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var person = await _context.Persons.FindAsync(request.PersonID);
                _context.Remove(person);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}