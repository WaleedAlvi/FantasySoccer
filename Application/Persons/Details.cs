using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Details
    {
        public class Query : IRequest<Person>
        {
            public Guid PersonID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Person>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Person> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Persons.FindAsync(request.PersonID);
            }
        }
    }
}