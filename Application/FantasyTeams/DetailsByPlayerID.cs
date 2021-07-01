using System;
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

namespace Application.FantasyTeams
{
    public class DetailsByPlayerID
    {
        public class Query : IRequest<Result<List<FantasyTeamDto>>>
        {
            public Guid PersonID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<FantasyTeamDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<List<FantasyTeamDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var fantasyTeam = await _context.FantasyTeams
                    .ProjectTo<FantasyTeamDto>(_mapper.ConfigurationProvider)
                    .Where(p => p.Person.PersonID.ToString() == request.PersonID.ToString())
                    .ToListAsync();

                return Result<List<FantasyTeamDto>>.Success(fantasyTeam);
            }
        }
    }
}