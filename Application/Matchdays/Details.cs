using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;



namespace Application.Matchdays
{
    public class Details
    {
        public class Query : IRequest<Result<MatchdayTeamMatchTeamConfigDto>>
        {
            public Guid FantasyTeamID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MatchdayTeamMatchTeamConfigDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<Result<MatchdayTeamMatchTeamConfigDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var matchdayTeamConfig = await _context.MatchdayTeamConfigurations
                    .ProjectTo<MatchdayTeamConfigDto>(_mapper.ConfigurationProvider)
                    .OrderBy(mtc => mtc.MatchdayTeamConfigurationID)
                    .LastOrDefaultAsync(mtc => mtc.FantasyTeamID == request.FantasyTeamID);

                var matchdayTeam = await _context.MatchdayTeams
                    .ProjectTo<MatchdayTeamDto>(_mapper.ConfigurationProvider)
                    .OrderBy(mt => mt.MatchdayTeamID)
                    .LastOrDefaultAsync(mt => mt.MatchdayTeamConfigurationID == matchdayTeamConfig.MatchdayTeamConfigurationID);

                var matchdayTeamMatchdayTeamConfig = new MatchdayTeamMatchTeamConfigDto
                {
                    MatchdayTeamConfig = matchdayTeamConfig,
                    MatchdayTeam = matchdayTeam
                };

                return Result<MatchdayTeamMatchTeamConfigDto>.Success(matchdayTeamMatchdayTeamConfig);
            }
        }
    }
}