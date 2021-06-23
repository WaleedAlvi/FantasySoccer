using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Players
{
    public class Details
    {
        public class Query : IRequest<Result<PlayerDto>>
        {
            public Guid PlayerID { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PlayerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<PlayerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = await _context.Players
                    .ProjectTo<PlayerDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.PlayerID == request.PlayerID);

                return Result<PlayerDto>.Success(person);
            }
        }
    }
}