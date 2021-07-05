using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FantasyLeagues
{
    public class PublicLeagueList
    {
        public class Query : IRequest<Result<List<FantasyLeagueDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<FantasyLeagueDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<List<FantasyLeagueDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var fantasyLeagues = await _context.FantasyLeagues
                    .Where(fl => fl.IsPublic == true)
                    .ProjectTo<FantasyLeagueDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<FantasyLeagueDto>>.Success(fantasyLeagues);
            }
        }
    }
}