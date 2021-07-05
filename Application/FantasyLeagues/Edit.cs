using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyLeague FantasyLeague { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FantasyLeague).SetValidator(new FantasyLeagueValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var fantasyLeague = await _context.FantasyLeagues.FindAsync(request.FantasyLeague.FantasyLeagueID);
                if (fantasyLeague == null) return null;
                _mapper.Map(request.FantasyLeague, fantasyLeague);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update fantasy league");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}