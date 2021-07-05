using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class InsertTeam
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyLeagueTeamDto FantasyLeagueTeam { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FantasyLeagueTeam).SetValidator(new FantasyLeagueTeamValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var newFantasyLeagueTeam = new Domain.FantasyLeagueTeams
                {
                    FantasyLeagueID = request.FantasyLeagueTeam.FantasyLeagueID,
                    FantasyTeamID = request.FantasyLeagueTeam.FantasyTeamID,
                };

                _context.FantasyLeagueTeams.Add(newFantasyLeagueTeam);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to add fantasy team to league");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}