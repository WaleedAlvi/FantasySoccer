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
    public class CreateTeam
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MatchdayTeamDto MatchdayTeam { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.MatchdayTeam).SetValidator(new MatchdayTeamDtoValidator());
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

                _context.MatchdayTeams.Add(new MatchdayTeam
                {
                    MatchdayTeamConfigurationID = request.MatchdayTeam.MatchdayTeamConfigurationID,
                    GoalieID = request.MatchdayTeam.GoalieID,
                    PlayerOneID = request.MatchdayTeam.PlayerOneID,
                    PlayerTwoID = request.MatchdayTeam.PlayerTwoID,
                    PlayerThreeID = request.MatchdayTeam.PlayerThreeID,
                    PlayerFourID = request.MatchdayTeam.PlayerFourID,
                    PlayerFiveID = request.MatchdayTeam.PlayerFiveID,
                    PlayerSixID = request.MatchdayTeam.PlayerSixID,
                    PlayerSevenID = request.MatchdayTeam.PlayerSevenID,
                    PlayerEightID = request.MatchdayTeam.PlayerEightID,
                    PlayerNineID = request.MatchdayTeam.PlayerNineID,
                    PlayerTenID = request.MatchdayTeam.PlayerTenID,
                    BenchOneID = request.MatchdayTeam.BenchOneID,
                    BenchTwoID = request.MatchdayTeam.BenchTwoID,
                    BenchThreeID = request.MatchdayTeam.BenchThreeID,
                    BenchFourID = request.MatchdayTeam.BenchFourID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                });

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create matchday team");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}