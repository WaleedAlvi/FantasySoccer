using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Persons
{
    public class Details
    {
        public class Query : IRequest<Result<PersonDto>>
        {
            public Guid PersonID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PersonDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<PersonDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = await _context.Persons
                    .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.PersonID == request.PersonID);

                return Result<PersonDto>.Success(person);
            }
        }
    }
}