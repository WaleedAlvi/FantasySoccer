using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Teams
{
    public class Details
    {
        public class Query : IRequest<Result<TeamDto>>
        {
            public Guid TeamID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TeamDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<TeamDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var team = await _context.Teams
                    .ProjectTo<TeamDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.TeamID == request.TeamID);

                return Result<TeamDto>.Success(team);
            }
        }
    }
}