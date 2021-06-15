using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Details
    {
        public class Query : IRequest<Result<Person>>
        {
            public Guid PersonID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Person>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Person>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<Person>.Success(await _context.Persons.FindAsync(request.PersonID));
            }
        }
    }
}