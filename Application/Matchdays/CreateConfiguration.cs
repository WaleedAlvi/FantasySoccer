using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Matchdays
{
    public class CreateConfiguration
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MatchdayTeamConfigDto MatchdayTeamConfig { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.MatchdayTeamConfig).SetValidator(new MatchdayTeamConfigDtoValidator());
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

                _context.MatchdayTeamConfigurations.Add(new MatchdayTeamConfiguration
                {
                    FantasyTeamID = request.MatchdayTeamConfig.FantasyTeamID,
                    MatchdayID = request.MatchdayTeamConfig.MatchdayID,
                    FormationID = request.MatchdayTeamConfig.FormationID,
                    CaptainID = request.MatchdayTeamConfig.CaptainID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                });
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to matchday team configuration");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
