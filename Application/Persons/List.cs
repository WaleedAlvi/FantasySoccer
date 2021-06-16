using System.Collections.Generic;
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
    public class List
    {
        public class Query : IRequest<Result<List<PersonDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<PersonDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<List<PersonDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var people = await _context.Persons
                    .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<PersonDto>>.Success(people);
            }
        }
    }
}