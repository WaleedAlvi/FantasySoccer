using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Matchdays
{
    public class EditTeam
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MatchdayTeam MatchdayTeam { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.MatchdayTeam).SetValidator(new MatchdayTeamValidator());
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
                var matchdayTeam = await _context.MatchdayTeams
                                            .FindAsync(request.MatchdayTeam.MatchdayTeamID);
                if (matchdayTeam == null) return null;
                _mapper.Map(request.MatchdayTeam, matchdayTeam);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update matchday team");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}