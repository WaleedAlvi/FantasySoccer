using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FantasyTeams
{
    public class DetailsByTeamID
    {
        public class Query : IRequest<Result<FantasyTeamDto>>
        {
            public Guid FantasyTeamID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<FantasyTeamDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<FantasyTeamDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var fantasyTeam = await _context.FantasyTeams
                    .ProjectTo<FantasyTeamDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.FantasyTeamID == request.FantasyTeamID);

                return Result<FantasyTeamDto>.Success(fantasyTeam);
            }
        }
    }
}