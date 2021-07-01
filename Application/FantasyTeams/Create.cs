using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyTeams
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyTeam FantasyTeam { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FantasyTeam).SetValidator(new FantasyTeamValidator());
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
                _context.FantasyTeams.Add(request.FantasyTeam);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create Fantasy Team");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}