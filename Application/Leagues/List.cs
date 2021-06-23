using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Leagues
{
    public class List
    {
        public class Query : IRequest<Result<List<LeagueDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<LeagueDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<Result<List<LeagueDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var leagues = await _context.Leagues
                    .ProjectTo<LeagueDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<LeagueDto>>.Success(leagues);

            }
        }
    }
}