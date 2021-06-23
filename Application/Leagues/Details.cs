using System;
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
    public class Details
    {
        public class Query : IRequest<Result<LeagueDto>>
        {
            public int APIFootballID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<LeagueDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<Result<LeagueDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var league = await _context.Leagues
                    .ProjectTo<LeagueDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.APIFootballID == request.APIFootballID);

                return Result<LeagueDto>.Success(league);
            }
        }
    }
}