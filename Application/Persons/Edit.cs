using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Persons
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Person Person { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var person = await _context.Persons.FindAsync(request.Person.PersonID);
                _mapper.Map(request.Person, person);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}