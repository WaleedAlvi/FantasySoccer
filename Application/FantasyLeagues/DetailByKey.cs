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
    public class DetailByKey
    {
        public class Query : IRequest<Result<FantasyLeagueDto>>
        {
            public string LeagueKey { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<FantasyLeagueDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<FantasyLeagueDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var fantasyLeague = await _context.FantasyLeagues
                    .ProjectTo<FantasyLeagueDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.LeagueKey == request.LeagueKey);

                return Result<FantasyLeagueDto>.Success(fantasyLeague);
            }
        }
    }
}