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

namespace Application.FantasyLeagues
{
    public class PersonActiveLeagues
    {
        public class Query : IRequest<Result<List<FantasyLeagueDto>>>
        {
            public Guid PersonID { get; set; }
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
                List<FantasyLeagueDto> fantasyLeagues = new List<FantasyLeagueDto>();
                var query = await (from fl in _context.FantasyLeagues
                                   join flt in _context.FantasyLeagueTeams on fl.FantasyLeagueID equals flt.FantasyLeagueID
                                   join ft in _context.FantasyTeams on flt.FantasyTeamID equals ft.FantasyTeamID
                                   where ft.PersonID == request.PersonID
                                   select new
                                   {
                                       FantasyLeagueID = fl.FantasyLeagueID,
                                       LeagueName = fl.LeagueName,
                                       LeagueCaption = fl.LeagueCaption,
                                       LeagueLogo = fl.LeagueLogo,
                                       IsPublic = fl.IsPublic,
                                       LeagueKey = fl.LeagueKey,
                                       NumberOfTeams = fl.NumberOfTeams,
                                       FantasyLeagueAdmins = fl.FantasyLeagueAdmins,
                                       FantasyLeagueTeams = fl.FantasyLeagueTeams,
                                   }).ToListAsync();

                foreach (var fantasyLeague in query)
                {
                    FantasyLeagueDto fantasyLeagueDto = new FantasyLeagueDto
                    {
                        FantasyLeagueID = fantasyLeague.FantasyLeagueID,
                        LeagueName = fantasyLeague.LeagueName,
                        LeagueCaption = fantasyLeague.LeagueCaption,
                        LeagueLogo = fantasyLeague.LeagueLogo,
                        IsPublic = fantasyLeague.IsPublic,
                        LeagueKey = fantasyLeague.LeagueKey,
                        NumberOfTeams = fantasyLeague.NumberOfTeams,
                    };

                    fantasyLeagues.Add(fantasyLeagueDto);
                }

                if (fantasyLeagues.Count < 1) return null;

                return Result<List<FantasyLeagueDto>>.Success(fantasyLeagues);
            }
        }
    }
}