using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyLeagueCreateDto FantasyLeague { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FantasyLeague).SetValidator(new FantasyLeagueCreateValidator());
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
                var newFantasyLeague = new FantasyLeague
                {
                    LeagueName = request.FantasyLeague.LeagueName,
                    LeagueCaption = request.FantasyLeague.LeagueCaption,
                    LeagueLogo = request.FantasyLeague.LeagueLogo,
                    IsPublic = request.FantasyLeague.IsPublic,
                    LeagueKey = request.FantasyLeague.LeagueKey,
                    NumberOfTeams = request.FantasyLeague.NumberOfTeams,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                _context.FantasyLeagues.Add(newFantasyLeague);

                _context.FantasyLeaguesAdmins.Add(new FantasyLeagueAdmin
                {
                    FantasyLeagueID = newFantasyLeague.FantasyLeagueID,
                    PersonID = request.FantasyLeague.AdminID,
                });
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create fantasy team");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}